using Settings;
using UI;
using UnityEngine;
using Zenject;

public class RaidActionsNavigationElementBase : NavigationElementBase 
{
    [Inject] private RaidManager _raidManager;
    [Inject] private GameManager _gameManager;
    
    public RaidActionsNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidActions; 
    } 
    
    public override bool IsActive() 
    { 
        return _gameManager.CurrentGameState == GameManager.GameState.Raid; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var actionsSettings = SettingsProvider.Get<LocationsList>().GetLocation(_raidManager.CurrentLocation).GetSubLocationSetting(_raidManager.CurrentSubLocation).ActionSettings;
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<RaidActionsPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new RaidActionsPanelSettings()
        {
            ActionSettings = actionsSettings
        });
        return panel;
    }
}