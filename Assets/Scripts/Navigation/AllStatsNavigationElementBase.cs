using System.Collections.Generic;
using UI;
using UnityEngine;

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

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<StatsPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new StatsPanelSettings
        {
            TitleText = "AllStats",
            StatsElements = new List<(string, string)>
            {
                ("Test1", "Test2"),
                ("Test3", "Test3"),
            }
        });
        return panel;
    }
}