using System.Collections.Generic;
using UnityEngine;
using VInspector;

[CreateAssetMenu(menuName = "EscapeFromCity/Items/WeaponTypeSetting", fileName = "WeaponTypeSetting", order = 0)]
public class WeaponTypeSetting : ScriptableObject
{
    [field: SerializeField] public SerializedDictionary<WeaponType, List<ItemType>> WeaponTypes { get; private set;}
}