using UnityEngine;
using Zenject;

public class ItemsNavigationElementBase : NavigationElementBase
{
    public ItemsNavigationElementBase()
    {
        ThisNavigationElementType = NavigationElementType.Items; 
    }

    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent, Player player)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<InventoryPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new InventoryPanelSettings()
        {
            Title = "Inventory",
            Items = player.Inventory.Items
        });
        return panel;
    }
}