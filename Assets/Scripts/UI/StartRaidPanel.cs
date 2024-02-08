using System;
using System.Collections.Generic;
using System.Linq;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartRaidPanel : Panel<StartRaidPanelSettings>
    {
        [SerializeField] private CharacterPanel _characterPanel;
        [SerializeField] private CharacterPanel _trampPanel;
        [SerializeField] private List<EquipmentPanelSetting> _equipmentPanels;
        [SerializeField] private TimePanel _dayTimePanels;
        [SerializeField] private TimePanel _nightTimePanels;
        [SerializeField] private Transform _locationsParent;
        [SerializeField] private Button _startRaidButton;

        private LocationType _selectedLocationType;
        private RaidTime _selectedDateTime;
        private CharacterType _selectedCharacterType;
        
        private List<LocationPanel> _locationPanels = new List<LocationPanel>();
        
        public override void Setup(StartRaidPanelSettings settings)
        {
            SetupCharactersPanel(settings);

            EquipmentPanelsSetup(settings);

            TimePanelsSetup();

            LocationPanelsSetup();
            
            _startRaidButton.onClick.AddListener((() =>
            {
                settings.RaidManager.StartRaid(_selectedLocationType, _selectedCharacterType, _selectedDateTime);
            }));
        }

        private void EquipmentPanelsSetup(StartRaidPanelSettings settings)
        {
            foreach (var equipmentPanelSetting in _equipmentPanels)
            {
                equipmentPanelSetting.EquipmentPanel.Setup(equipmentPanelSetting.ItemCategoryType.ToString(),
                    SettingsProvider.Get<PrefabSettings>().TestImage, 
                    () =>
                    {
                        settings.PopupController.ShowPopup(new SelectItemPopupSetting());
                    });
            }
        }

        private void LocationPanelsSetup()
        {
            var locationSettings = SettingsProvider.Get<LocationsList>();
            foreach (var locationSetting in locationSettings.Locations)
            {
                var locationPanelPrefab = SettingsProvider.Get<PrefabSettings>().LocationPanelPrefab;
                var newLocation = Instantiate(locationPanelPrefab, _locationsParent);
                newLocation.Setup(locationSetting.Name, locationSetting.Sprite, () =>
                {
                    _selectedLocationType = locationSetting.LocationType; 
                    foreach (var locationPanel in _locationPanels)
                    {
                        locationPanel.Activate(locationPanel == newLocation);
                    }
                });
                _locationPanels.Add(newLocation);

                newLocation.Activate(_locationPanels.First() == newLocation);
            }
        }

        private void TimePanelsSetup()
        {
            _dayTimePanels.Setup((() =>
            {
                _selectedDateTime = RaidTime.Day;
                _dayTimePanels.Activate(true);
                _nightTimePanels.Activate(false);
            }));
            _nightTimePanels.Setup((() =>
            {
                _selectedDateTime = RaidTime.Night;
                _dayTimePanels.Activate(false);
                _nightTimePanels.Activate(true);
            }));
            _dayTimePanels.Activate(true);
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
                _selectedCharacterType = CharacterType.Character;
                _characterPanel.Activate(true);
                _trampPanel.Activate(false);
                EnableEquipment(true);
            });
            _characterPanel.Activate(true);
            EnableEquipment(true);

            _trampPanel.Setup("OLEG EBLAN", SettingsProvider.Get<PrefabSettings>().TrampImage, () =>
            {
                _selectedCharacterType = CharacterType.Tramp;
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
        public PopupController PopupController;
        public RaidManager RaidManager;
    }
}