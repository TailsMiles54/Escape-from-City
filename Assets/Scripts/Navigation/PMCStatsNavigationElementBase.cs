using System.Collections.Generic;
using UI;
using UnityEngine;

public class PMCStatsNavigationElementBase : NavigationElementBase 
{
    public PMCStatsNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.PMCStats; 
    } 
    
    public override bool IsActive() 
    { 
        return true; 
    } 

    public override BasePanel CreatePanel(Transform transformParent, Player player, PopupController popupController)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<StatsPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new StatsPanelSettings
        {
            TitleText = "ЧВК стата",
            StatsElements = new List<(string, string)>
            {
                ("Рейдов", "2"),
                ("Выжил", "1"),
            }
        });
        return panel;
    }
}