using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Locations/SubLocationSettings", fileName = "SubLocationSettings", order = 0)]
public class SubLocationSettings : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set;}
    [field: SerializeField] public SubLocationType ThisSubLocationType { get; private set;}
    [field: SerializeField] public List<SubLocationType> TransitionLocations { get; private set;}
    [field: SerializeField] public List<ActionSetting> ActionSettings { get; private set;}
    [field: SerializeField] public bool ExitPoint { get; private set;}
    public void Init(SubLocationType subLocationType)
    {
        Name = subLocationType.ToString();
        ThisSubLocationType = subLocationType;
    }
}