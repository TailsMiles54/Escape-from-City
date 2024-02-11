using UI;
using UnityEngine;
using Zenject;

public class RaidTimerNavigationElementBase : NavigationElementBase 
{
    [Inject] private RaidManager _raidManager;
    [Inject] private GameManager _gameManager;
    
    public RaidTimerNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidTimer; 
    } 
    
    public override bool IsActive() 
    { 
        return _gameManager.CurrentGameState == GameManager.GameState.Raid; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<RaidTimerPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new RaidTimerPanelSettings()
        {
            RaidManager = _raidManager
        });
        return panel;
    }
}