using UnityEngine;

public class NpcNavigationElementBase : NavigationElementBase 
{
    public NpcNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.NPC; 
    } 
    
    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent, Player player)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<TraderPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new TraderPanelSettings
        {
            Text = "Имя",
            Image = null,
            Second1Text = "Test1",
            Second2Text = "Test2",
            Second3Text = "Test3",
            Button1Text = "Test4",
            Button2Text = "Test5",
            Button3Text = "Test6",
        });
        return panel;
    }
}