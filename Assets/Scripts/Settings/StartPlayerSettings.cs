using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/PlayerSettings/StartPlayerSettings", fileName = "StartPlayerSettings", order = 0)]
public class StartPlayerSettings : ScriptableObject
{
    [field: SerializeField] public List<Item> StartItems { get; private set; }
    [field: SerializeField] public int StartedInventorySize { get; private set; }
}