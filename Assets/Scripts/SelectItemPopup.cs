using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemPopup : Popup<SelectItemPopupSetting>
{
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private InventoryElement _inventoryElement;

    [SerializeField] private Button _close;
    
    public override void Setup(SelectItemPopupSetting setting)
    {
        var inventory = setting.Player.Inventory;
        var items = inventory.Items.Where(x => x.Setting.ItemCategoryType == setting.ItemCategoryType);

        _close.onClick.AddListener(() => setting.PopupController.HidePopup());
        
        foreach (var item in items)
        {
            var itemObject = Instantiate(_inventoryElement, _itemsParent);
            itemObject.Setup(item, () =>
            {
                setting.PopupController.HidePopup();
                setting.PopupController.ShowPopup(new AcceptPopupSetting()
                {
                    Title = "Подтверждение",
                    Content = $"Выбрать {item.ItemType.ToString()} для рейда?",
                    Icon = item.Setting.Sprite,
                    AcceptItemAction = () =>
                    {
                        setting.PopupController.HidePopup();
                        setting.EquipmentReserveManager.SelectItem(item);
                        setting.UIService.TabUpdate();
                    },
                    NotAcceptItemAction = setting.PopupController.HidePopup,
                });
            });
        }
    }
}

public class SelectItemPopupSetting : BasePopupSettings
{
    public ItemCategoryType ItemCategoryType;
    public Player Player;
    public PopupController PopupController;
    public EquipmentReserveManager EquipmentReserveManager;
    public UIService UIService;
}