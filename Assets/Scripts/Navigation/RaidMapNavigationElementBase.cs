using Settings;
using UI;
using UnityEngine;
using Zenject;

public class RaidMapNavigationElementBase : NavigationElementBase
{
    [Inject] private RaidManager _raidManager;
    [Inject] private GameManager _gameManager;
    
    public RaidMapNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidMap; 
    } 
    
    public override bool IsActive() 
    { 
        return _gameManager.CurrentGameState == GameManager.GameState.Raid; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<RaidMapPanel>();
        var panel = Object.Instantiate(prefab, transformParent);

        var locationMap = SettingsProvider.Get<LocationsList>().GetLocation(_raidManager.CurrentLocation).LocationMap;
        
        panel.Setup(new RaidMapPanelSettings()
        {
            MapItem = locationMap
        });
        return panel;
    }
}