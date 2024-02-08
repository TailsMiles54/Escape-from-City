using System.Linq;
using Settings;
using UnityEngine;
using Zenject;

public class ItemsNavigationElementBase : NavigationElementBase
{
    [Inject] private Player _player;
    [Inject] private GameManager _gameManager;
    public ItemsNavigationElementBase()
    {
        ThisNavigationElementType = NavigationElementType.Items; 
    }

    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<InventoryPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new InventoryPanelSettings()
        {
            Title = $"Inventory \n Slots: {_player.Inventory.Items.Sum(x => SettingsProvider.Get<ItemsList>().GetItem(x.ItemType).ItemSize)}/{_player.Inventory.AvailableSlots}",
            Items = _player.Inventory.Items
        });
        return panel;
    }
}