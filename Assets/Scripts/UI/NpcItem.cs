using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class NpcItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleTMP;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _second1TMP;

    [SerializeField] private Transform _itemsParent;

    [SerializeField] private List<GameObject> _items = new List<GameObject>();
    
    [Tab("ButtonTexts")]
    [SerializeField] private TMP_Text _button1Text;
    [SerializeField] private TMP_Text _button2Text;
    [SerializeField] private TMP_Text _button3Text;
    [Tab("Buttons")]
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private Button _buttonQuest;
    [SerializeField] private Button _buttonSell;
    
    private bool _inAnimationProcess;

    private TabType _currentTabType;

    private Player _player;
    private PopupController _popupController;
    private NpcSetting _traderSetting;
    
    public void Setup(NpcSetting settings, Player player, PopupController popupController)
    {
        _player = player;
        _popupController = popupController;
        _traderSetting = SettingsProvider.Get<NpcSettingsList>().GetNpcSetting(settings.NpcType);
        
        _titleTMP.text = settings.Name;
        _image.sprite = settings.Sprite;
        _second1TMP.text = settings.Bio;
        _button1Text.text = "Buy";
        _button2Text.text = "Quests";
        _button3Text.text = "Sell";

        player.Inventory.InventoryUpdated += InventoryUpdate;
        
        _buttonBuy.onClick.AddListener(() =>
        {
            if(_inAnimationProcess)
                return;
            
            OpenOrHideBottom(TabType.Buy, BuyItems);
        });
        
        _buttonSell.onClick.AddListener(() =>
        {
            if(_inAnimationProcess)
                return;
            
            OpenOrHideBottom(TabType.Sell, SellItems);
        });
    }

    private void OnDestroy()
    {
        _player.Inventory.InventoryUpdated -= InventoryUpdate;
    }

    private void BuyItems()
    {
        var itemsSell = _traderSetting.ItemSell;
        var inventoryElementPrefab = SettingsProvider.Get<PrefabSettings>().InventoryElement;
            
        for (int i = _items.Count-1; _items.Count > 0 && i >= 0 ; i--)
        {
            var child = _items[i];
            Destroy(child.gameObject);
        }
        
        _items.Clear();
            
        foreach (var item in itemsSell)
        {
            var inventoryItem = Instantiate(inventoryElementPrefab, _itemsParent);
            inventoryItem.Setup(item, () =>
            {
                _popupController.ShowPopup(new AcceptPopupSetting()
                {
                    Title = "Подтверждение",
                    Content = $"Вы действительно хотите купить {item.ItemType.ToString()}?",
                    Icon = item.Setting.Sprite,
                    AcceptItemAction = () =>
                    {
                        _player.Inventory.AddItem(item);
                        _popupController.HidePopup();
                    },
                    NotAcceptItemAction = _popupController.HidePopup,
                });
            });
            _items.Add(inventoryItem.gameObject);
        }
                
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        Canvas.ForceUpdateCanvases();
    }

    private void SellItems()
    {
        var traderCategories = _traderSetting.ItemCategory;
            
        var playerItemsInCategories = _player.Inventory.Items.Where(x => traderCategories.Contains(x.ItemCategoryType)).ToList();
            
        var inventoryElementPrefab = SettingsProvider.Get<PrefabSettings>().InventoryElement;
            
        for (int i = _items.Count-1; _items.Count > 0 && i >= 0 ; i--)
        {
            var child = _items[i];
            Destroy(child.gameObject);
        }
        
        _items.Clear();
            
        foreach (var item in playerItemsInCategories)
        {
            var inventoryItem = Instantiate(inventoryElementPrefab, _itemsParent);
            inventoryItem.Setup(item, () =>
            {
                _popupController.ShowPopup(new AcceptPopupSetting()
                {
                    Title = "Подтверждение",
                    Content = $"Вы действительно хотите продать {item.ItemType.ToString()}?",
                    Icon = item.Setting.Sprite,
                    AcceptItemAction = () =>
                    {
                        _player.Inventory.RemoveItem(item);
                        _popupController.HidePopup();
                    },
                    NotAcceptItemAction = _popupController.HidePopup,
                });
            });
            _items.Add(inventoryItem.gameObject);
        }
                
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        Canvas.ForceUpdateCanvases();
    }

    private void OpenOrHideBottom(TabType clickedTab, Action action = null)
    {
        _inAnimationProcess = true;
        
        if (_itemsParent.gameObject.activeSelf)
        {
            Close(clickedTab, action);
        }
        else
        {
            action?.Invoke();
            Open();
        }
    }

    private void InventoryUpdate()
    {
        if (_currentTabType == TabType.Sell)
        {
            UpdateSellTab(TabType.Sell, SellItems);
        }
    }

    private void Close(TabType clickedTab, Action action = null)
    {
        _itemsParent.transform.DOScaleY(0, 1f).OnUpdate(UpdateLayoutGroup).onComplete = () =>
        {
            _itemsParent.gameObject.SetActive(false); 
            UpdateLayoutGroup();
            action?.Invoke();
                
            _inAnimationProcess = false;

            if (clickedTab != _currentTabType)
            {
                Open();
            }

            _currentTabType = clickedTab;
        };
    }

    private void UpdateSellTab(TabType clickedTab, Action action = null)
    {
        _itemsParent.transform.DOScaleY(0, 1f).OnUpdate(UpdateLayoutGroup).onComplete = () =>
        {
            _itemsParent.gameObject.SetActive(false); 
            UpdateLayoutGroup();
            action?.Invoke();
            
            Open();
                
            _inAnimationProcess = false;
            _currentTabType = clickedTab;
        };
    }

    private void Open()
    {
        _itemsParent.gameObject.SetActive(true); 
        _itemsParent.transform.DOScaleY(1, 1f).OnUpdate(UpdateLayoutGroup).onComplete = () =>
        {
            UpdateLayoutGroup();
                
            _inAnimationProcess = false;
        };
    }

    private void UpdateLayoutGroup()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.parent.GetComponent<RectTransform>());
    }

    private enum TabType
    {
        None = 0,
        Buy = 1,
        Quest = 2,
        Sell = 3,
    }
}