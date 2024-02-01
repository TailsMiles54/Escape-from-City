using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class NavigationController
{
    [Inject] private Player _player;
    [Inject] private PopupController _popupController;
    
    private List<NavigationElementBase> NavigationElements = new List<NavigationElementBase>()
    {
        new AllStatsNavigationElementBase(),
        new SkillsNavigationElementBase(),
        new PMCStatsNavigationElementBase(),
        new TrampStatsNavigationElementBase(),
        new ItemsNavigationElementBase(),
        new NpcNavigationElementBase(),
        new ShelterElementsNavigationElementBase(),
        new RaidStartNavigationElementBase(),
        new RaidProcessNavigationElementBase(),
    };
    
    public bool IsActive(NavigationElementType navigationElementType)
    {
        if (NavigationElements.All(x => x.ThisNavigationElementType != navigationElementType))
        {
            Debug.LogWarning($"NavigationController not contain BaseElement for {navigationElementType}");
            return false;
        }
        
        return NavigationElements
            .First(x => x.ThisNavigationElementType == navigationElementType).IsActive();
    }

    public BasePanel GetPanel(NavigationElementType navigationElementType, Transform transformParent)
    {
        return NavigationElements
            .First(x => x.ThisNavigationElementType == navigationElementType).CreatePanel(transformParent, _player, _popupController);
    }
}