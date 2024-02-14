using UnityEngine;
using Zenject;

public class NpcNavigationElementBase : NavigationElementBase 
{
    [Inject] private GameManager _gameManager;
    
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
        var traders = SettingsProvider.Get<NpcSettingsList>();
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<NpcPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new NpcPanelSettings());
        return panel;
    }
}