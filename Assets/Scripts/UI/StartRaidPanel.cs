using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartRaidPanel : Panel<StartRaidPanelSettings>
    {
        [SerializeField] private CharacterPanel _characterPanel;
        [SerializeField] private CharacterPanel _trampPanel;

        [SerializeField] private List<EquipmentPanelSetting> _equipmentPanels;
        
        public override void Setup(StartRaidPanelSettings settings)
        {
            SetupCharactersPanel(settings);

            foreach (var equipmentPanelSetting in _equipmentPanels)
            {
                equipmentPanelSetting.EquipmentPanel.Setup(equipmentPanelSetting.ItemCategoryType.ToString(),
                    SettingsProvider.Get<PrefabSettings>().TestImage, 
                    () =>
                    {
                        Debug.Log($"Open {equipmentPanelSetting.ItemCategoryType}");
                    });
            }
        }

        private void EnableEquipment(bool state)
        {
            foreach (var equipmentPanelSetting in _equipmentPanels)
            {
                equipmentPanelSetting.EquipmentPanel.Activate(state);
            }
        }

        private void SetupCharactersPanel(StartRaidPanelSettings settings)
        {
            _characterPanel.Setup(settings.Player.Name, SettingsProvider.Get<PrefabSettings>().PMCImage, () =>
            {
                _characterPanel.Activate(true);
                _trampPanel.Activate(false);
                EnableEquipment(true);
            });
            _characterPanel.Activate(true);
            EnableEquipment(true);

            _trampPanel.Setup("OLEG EBLAN", SettingsProvider.Get<PrefabSettings>().TrampImage, () =>
            {
                _characterPanel.Activate(false);
                _trampPanel.Activate(true);
                EnableEquipment(false);
            });
            _trampPanel.Activate(false);
        }

        [Serializable]
        public class EquipmentPanelSetting
        {
            public ItemCategoryType ItemCategoryType;
            public EquipmentPanel EquipmentPanel;
        }
    }

    public class StartRaidPanelSettings : BasePanelSettings
    {
        public Player Player;
    }
}