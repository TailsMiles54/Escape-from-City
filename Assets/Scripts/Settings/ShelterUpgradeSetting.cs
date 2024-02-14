using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Shelter/ShelterUpgradeSetting", fileName = "ShelterUpgradeSetting", order = 0)]
public class ShelterUpgradeSetting : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set;}
    [field: SerializeField] public ShelterUpgradeType UpgradeType { get; private set;}
    [field: SerializeField] public int MaxLevel { get; private set;}
    
    public void Init(ShelterUpgradeType upgradeType)
    {
        Name = upgradeType.ToString();
        UpgradeType = upgradeType;
    }
}