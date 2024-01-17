using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Navigation/NavigationElementSettingsList",
    fileName = "NavigationElementSettingsList", order = 0)]
public class NavigationElementSettingsList : ScriptableObject
{
    [field: SerializeField]public List<NavigationElementSettings> ChildElements { get; private set; }

    public List<NavigationElementType> GetChildElements(NavigationElementType navigationElementType) =>
        ChildElements.First(x => x.NavigationElementType == navigationElementType).ChildElements;
}