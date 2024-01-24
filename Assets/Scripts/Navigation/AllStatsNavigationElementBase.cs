using System.Collections.Generic;
using UI;

public class AllStatsNavigationElementBase : NavigationElementBase
{
    public AllStatsNavigationElementBase()
    {
        ThisNavigationElementType = NavigationElementType.AllStats;
    }
    
    public override bool IsActive()
    {
        return true;
    }

    public override BasePanel CreatePanel()
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<StatsPanel>();
        prefab.Setup(new StatsPanelSettings
        {
            TitleText = "AllStats",
            StatsElements = new List<(string, string)>
            {
                ("Test1", "Test2"),
                ("Test3", "Test3"),
            }
        });
        return prefab;
    }
}