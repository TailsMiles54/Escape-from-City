using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Shelter/ShelterUpgrades", fileName = "ShelterUpgradesList", order = 0)]
public class ShelterUpgradesList : ScriptableObject
{
    [field: SerializeField] public List<ShelterUpgradeSetting> Upgrades { get; private set;}

    public void AddItem(ShelterUpgradeSetting shelterUpgradeSetting)
    {
        Upgrades.Add(shelterUpgradeSetting);
    }
    
    public ShelterUpgradeSetting GetSetting(ShelterUpgradeType upgradeType) =>
        Upgrades.First(x => x.UpgradeType == upgradeType);
}