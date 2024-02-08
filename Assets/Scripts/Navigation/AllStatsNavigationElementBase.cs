using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

public class AllStatsNavigationElementBase : NavigationElementBase
{
    [Inject] private Player _player;
    [Inject] private GameManager _gameManager;
    
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
                ("NickName", _player.Name),
                ("Test3", "Test3"),
            }
        });
        return panel;
    }
}