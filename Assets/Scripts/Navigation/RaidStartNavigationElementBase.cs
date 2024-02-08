using UI;
using UnityEngine;
using Zenject;

public class RaidStartNavigationElementBase : NavigationElementBase 
{
    [Inject] private Player _player;
    [Inject] private PopupController _popupController;
    
    public RaidStartNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidStart; 
    } 
    
    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<StartRaidPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new StartRaidPanelSettings()
        {
            Player = _player,
            PopupController = _popupController
        });
        return panel;
    }
}