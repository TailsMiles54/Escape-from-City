using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Locations/LocationSettings", fileName = "LocationSettings", order = 0)]
public class LocationSettings : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set;}
    [field: SerializeField] public LocationType LocationType { get; private set;}
    [field: SerializeField] public MapItem LocationMap { get; private set; }
    [field: SerializeField] public List<SubLocationSettings> SubLocationSettings { get; private set;}
    [field: SerializeField] public Sprite Sprite { get; private set;}
    [field: SerializeField] public int LocationTime { get; private set;}
    
    public void Init(LocationType locationType)
    {
        Name = locationType.ToString();
        LocationType = locationType;
    }

    public SubLocationSettings GetRandomSubLocation()
    {
        return SubLocationSettings.GetRandomElement();
    }
}