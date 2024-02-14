using UI;
using UnityEngine;
using Zenject;

public class RaidStatsNavigationElementBase : NavigationElementBase 
{
    [Inject] private RaidManager _raidManager;
    [Inject] private GameManager _gameManager;
    
    public RaidStatsNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidStats; 
    } 
    
    public override bool IsActive() 
    { 
        return _gameManager.CurrentGameState == GameManager.GameState.Raid; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        //CТАТСОВ ПОКА НЕТ НО БУДЕТ
        
        // var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<RaidStatsPanel>();
        // var panel = Object.Instantiate(prefab, transformParent);
        // panel.Setup(new RaidStatsPanelSettings()
        // {
        // });
        // return panel;

        return null;
    }
}