using UnityEngine;
using Zenject;

public class NpcNavigationElementBase : NavigationElementBase 
{
    [Inject] private GameManager _gameManager;
    [Inject] private Player _player;
    
    public NpcNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.NPC; 
    } 
    
    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<NpcPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new NpcPanelSettings()
        {
            Player = _player
        });
        return panel;
    }
}