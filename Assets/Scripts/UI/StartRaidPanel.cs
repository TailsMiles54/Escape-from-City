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
        [SerializeField] private Transform _equipmentPanelsParent;
        [SerializeField] private TimePanel _dayTimePanels;
        [SerializeField] private TimePanel _nightTimePanels;
        [SerializeField] private Transform _locationsParent;
        [SerializeField] private Button _startRaidButton;
        
        [SerializeField] private EquipmentPanel _equipmentPanel;
        
        private List<EquipmentPanel> _equipments = new List<EquipmentPanel>();
        private LocationType _selectedLocationType;
        private RaidTime _selectedDateTime;
        private CharacterType _selectedCharacterType;
        private EquipmentReserveManager _equipmentReserveManager;
        
        private List<LocationPanel> _locationPanels = new List<LocationPanel>();
        
        public override void Setup(StartRaidPanelSettings settings)
        {
            _equipmentReserveManager = settings.EquipmentReserveManager;
            _selectedCharacterType = CharacterType.Character;

            EquipmentPanelsSetup(settings);
            
            SetupCharactersPanel(settings);

            TimePanelsSetup();

            LocationPanelsSetup();

            ShowEquipment();
            
            _startRaidButton.onClick.AddListener((() =>
            {
                settings.RaidManager.StartRaid(_selectedLocationType, _selectedCharacterType, _selectedDateTime);
            }));
        }

        private void EquipmentPanelsSetup(StartRaidPanelSettings settings)
        {
            var categories = settings.EquipmentReserveManager.ReservedItems[CharacterType.Character].Items
                .Select(x => x.ItemCategoryType).ToList();
            foreach (var categoryType in categories)
            {
                var equipmentPanelSetting = Instantiate(_equipmentPanel, _equipmentPanelsParent);
                
                equipmentPanelSetting.Setup(categoryType.ToString(), categoryType,
                    SettingsProvider.Get<PrefabSettings>().TestImage, 
                    () =>
                    {
                        settings.PopupController.ShowPopup(new SelectItemPopupSetting()
                        {
                            Player = settings.Player,
                            EquipmentReserveManager = settings.EquipmentReserveManager,
                            PopupController = settings.PopupController,
                            ItemCategoryType = equipmentPanelSetting.ItemCategoryType,
                            UIService = settings.UIService,
                        });
                    });
                
                _equipments.Add(equipmentPanelSetting);
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

        private void EnableEquipment()
        {
            var state = _selectedCharacterType == CharacterType.Character;
            foreach (var panel in _equipments)
            {
                panel.Activate(state);
            }
        }

        private void ShowEquipment()
        {
            var equipment = _equipmentReserveManager.ReservedItems[_selectedCharacterType];
            
            foreach (var panel in _equipments)
            {
                var itemType = panel.ItemCategoryType;
                var item = equipment.Items.First(x => x.ItemCategoryType == itemType).Item;
                
                if(item == null)
                {
                    panel.SetEmpty();
                    break;
                }
                        
                panel.SetItem(item.ItemType);
            }
        }

        private void SetupCharactersPanel(StartRaidPanelSettings settings)
        {
            _characterPanel.Setup(settings.Player.Name, SettingsProvider.Get<PrefabSettings>().PMCImage, () =>
            {
                _selectedCharacterType = CharacterType.Character;
                _characterPanel.Activate(true);
                _trampPanel.Activate(false);
                EnableEquipment();
                ShowEquipment();
            });
            _characterPanel.Activate(true);
            EnableEquipment();

            _trampPanel.Setup("OLEG EBLAN", SettingsProvider.Get<PrefabSettings>().TrampImage, () =>
            {
                _selectedCharacterType = CharacterType.Tramp;
                _characterPanel.Activate(false);
                _trampPanel.Activate(true);
                EnableEquipment();
                ShowEquipment();
            });
            _trampPanel.Activate(false);
        }
    }

    public class StartRaidPanelSettings : BasePanelSettings
    {
        public Player Player;
        public PopupController PopupController;
        public RaidManager RaidManager;
        public EquipmentReserveManager EquipmentReserveManager;
        public UIService UIService;
    }
}