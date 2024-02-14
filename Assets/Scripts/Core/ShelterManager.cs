using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

public class ShelterManager : IInitializable
{
    [Inject] private SaveManager _saveManager;
    [Inject] private UIService _uiService;
    public Dictionary<ShelterUpgradeType, int> ShelterUpgrades { get; private set; }
    
    public void Initialize()
    {
        LoadShelterData();
        var upgrades = Enum.GetValues(typeof(ShelterUpgradeType)).Cast<ShelterUpgradeType>().ToList();
        foreach (var upgradeType in upgrades)
        {
            ShelterUpgrades.TryAdd(upgradeType, 0);
        }
        _saveManager.SaveShelterData(ShelterUpgrades);
    }

    private void LoadShelterData()
    {
        _saveManager.LoadShelterData(out Dictionary<ShelterUpgradeType, int> shelterUpgradeSaveData);
        ShelterUpgrades = shelterUpgradeSaveData;
    }

    public void UpgradeShelter(ShelterUpgradeType shelterUpgrade)
    {
        ShelterUpgrades[shelterUpgrade]++;
        _uiService.TabUpdate();
        _saveManager.SaveShelterData(ShelterUpgrades);
    }
}