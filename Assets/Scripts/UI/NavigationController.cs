using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavigationController
{
    public List<NavigationElementBase> NavigationElements = new List<NavigationElementBase>()
    {
        new AllStatsNavigationElementBase()
    };

    public bool IsActive(NavigationElementType navigationElementType) => NavigationElements
        .First(x => x.ThisNavigationElementType == navigationElementType).IsActive();
    
    public BasePanel GetPanel(NavigationElementType navigationElementType) => NavigationElements
        .First(x => x.ThisNavigationElementType == navigationElementType).CreatePanel();
}