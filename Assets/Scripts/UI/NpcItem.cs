using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleTMP;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _second1TMP;
    [SerializeField] private TMP_Text _button1Text;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private TMP_Text _button2Text;
    [SerializeField] private Button _buttonQuest;
    [SerializeField] private TMP_Text _button3Text;
    [SerializeField] private Button _buttonSell;

    [SerializeField] private Transform _itemsParent;

    [SerializeField] private List<GameObject> _items = new List<GameObject>();
    
    public void Setup(NpcSetting settings)
    {
        var traderSetting = SettingsProvider.Get<NpcSettingsList>().GetNpcSetting(settings.NpcType);
        
        _titleTMP.text = settings.Name;
        _image.sprite = settings.Sprite;
        _second1TMP.text = settings.Bio;
        _button1Text.text = "Buy";
        _button2Text.text = "Quests";
        _button3Text.text = "Sell";
        
        _buttonBuy.onClick.AddListener(() =>
        {
            var itemsSell = traderSetting.ItemSell;
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
                inventoryItem.Setup(item);
                _items.Add(inventoryItem.gameObject);
            }

            OpenOrHideBottom();
            
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
            Canvas.ForceUpdateCanvases();
        });
    }

    public void OpenOrHideBottom()
    {
        if (_itemsParent.gameObject.activeSelf)
        {
            _itemsParent.transform.DOScaleY(0, 1f).OnUpdate(UpdateLayoutGroup).onComplete = () =>
            {
                _itemsParent.gameObject.SetActive(false); 
                UpdateLayoutGroup();
            };
        }
        else
        {
            _itemsParent.gameObject.SetActive(true); 
            _itemsParent.transform.DOScaleY(1, 1f).OnUpdate(UpdateLayoutGroup).onComplete = UpdateLayoutGroup;
        }
    }

    private void UpdateLayoutGroup()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.parent.GetComponent<RectTransform>());
    }
}

public class NpcPanelSettings : BasePanelSettings
{
}