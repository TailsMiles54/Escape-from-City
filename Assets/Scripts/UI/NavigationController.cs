using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavigationController
{
    public List<NavigationElementBase> NavigationElements = new List<NavigationElementBase>()
    {
        new AllStatsNavigationElementBase()
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
            .First(x => x.ThisNavigationElementType == navigationElementType).CreatePanel(transformParent);
    }
}