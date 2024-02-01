using UI;
using UnityEngine;

public class RaidStartNavigationElementBase : NavigationElementBase 
{
    public RaidStartNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidStart; 
    } 
    
    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent, Player player, PopupController popupController)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<StartRaidPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new StartRaidPanelSettings()
        {
            Player = player,
            PopupController = popupController
        });
        return panel;
    }
}