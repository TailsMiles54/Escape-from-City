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
            var upgrades = Enum.GetValues(typeof(ShelterUpgrade)).Cast<ShelterUpgrade>().ToList();
            foreach (var shelterUpgrade in upgrades)
            {
                var shelterItem = Instantiate(actionItemPrefab, _actionsParent);
                shelterItem.Setup(settings.ShelterManager, shelterUpgrade);
            }
        }
    }
    public class ShelterPanelSettings : BasePanelSettings
    {
        public ShelterManager ShelterManager;
    }
}