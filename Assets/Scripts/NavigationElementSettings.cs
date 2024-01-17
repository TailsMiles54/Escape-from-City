using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Navigation/NavigationElementSettings",
    fileName = "NavigationElementSettings", order = 0)]
public class NavigationElementSettings : ScriptableObject
{
    [field: SerializeField]public NavigationElementType NavigationElementType { get; private set; }
    
    [field: SerializeField]public List<NavigationElementType> ChildElements { get; private set; }
}