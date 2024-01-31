using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "EscapeFromCity/Locations/LocationsList", fileName = "LocationsList", order = 0)]
    public class LocationsList : ScriptableObject
    {
        [field: SerializeField] public List<LocationSettings> Locations { get; private set;}

        public void AddItem(LocationSettings itemSetting)
        {
            Locations.Add(itemSetting);
        }

        public LocationSettings GetLocation(LocationType locationType) => Locations.First(x => x.LocationType == locationType);
    }
}