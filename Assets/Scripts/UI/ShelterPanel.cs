using System;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class ShelterPanel : Panel<ShelterPanelSettings>
    {
        [SerializeField] private Transform _actionsParent;
        public override void Setup(ShelterPanelSettings settings)
        {
            var actionItemPrefab = SettingsProvider.Get<PrefabSettings>().ShelterItem;
            var upgrades = settings.ShelterManager.ShelterUpgrades;
            foreach (var shelterUpgrade in upgrades)
            {
                var shelterItem = Instantiate(actionItemPrefab, _actionsParent);
                shelterItem.Setup(shelterUpgrade.Key, shelterUpgrade.Value, settings.ShelterManager);
            }
        }
    }
    public class ShelterPanelSettings : BasePanelSettings
    {
        public ShelterManager ShelterManager;
    }
}