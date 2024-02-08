using System.Collections.Generic;
using UI;
using UnityEngine;

public class TrampStatsNavigationElementBase : NavigationElementBase 
{
    public TrampStatsNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.TrampStats; 
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
            TitleText = "Статистика бродяги",
            StatsElements = new List<(string, string)>
            {
                ("Убитый", "1 раз"),
                ("Убил", "2 раза"),
            }
        });
        return panel;
    }
}