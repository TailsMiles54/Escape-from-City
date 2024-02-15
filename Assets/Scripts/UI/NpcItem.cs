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
            
            foreach (var item in itemsSell)
            {
                var inventoryItem = Instantiate(inventoryElementPrefab, _itemsParent);
                inventoryItem.Setup(item);
            }
            
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
            Canvas.ForceUpdateCanvases();
        });
    }
}

public class NpcPanelSettings : BasePanelSettings
{
}