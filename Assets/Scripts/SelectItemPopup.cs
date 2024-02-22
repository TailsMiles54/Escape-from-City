using System;
using System.Linq;
using UnityEngine;

public class SelectItemPopup : Popup<SelectItemPopupSetting>
{
    [SerializeField] private Transform _itemsParent; 
    
    public override void Setup(SelectItemPopupSetting setting)
    {
        var inventory = setting.Player.Inventory;
        var items = inventory.Items.Where(x => x.Setting.ItemCategoryType == setting.ItemCategoryType);

        var itemPrefab = SettingsProvider.Get<PrefabSettings>().InventoryElement;

        foreach (var item in items)
        {
            var itemObject = Instantiate(itemPrefab, _itemsParent);
            itemObject.Setup(item);
        }
    }
}

public class SelectItemPopupSetting : BasePopupSettings
{
    public ItemCategoryType ItemCategoryType;
    public Player Player;
    public EquipmentReserveManager EquipmentReserveManager;
}