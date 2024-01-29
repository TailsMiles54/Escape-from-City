using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartRaidPanel : Panel<StartRaidPanelSettings>
    {
        [SerializeField] private CharacterPanel _characterPanel;
        [SerializeField] private CharacterPanel _trampPanel;
        
        public override void Setup(StartRaidPanelSettings settings)
        {
            _characterPanel.Setup(settings.Player.Name, SettingsProvider.Get<PrefabSettings>().TestImage, () =>
            {
                _characterPanel.Activate(true);
                _trampPanel.Activate(false);
            });
            _characterPanel.Activate(true);
            
            _trampPanel.Setup("OLEG EBLAN", SettingsProvider.Get<PrefabSettings>().TestImage, () =>
            {
                _characterPanel.Activate(false);
                _trampPanel.Activate(true);
            });
            _trampPanel.Activate(false);
        }
    }

    public class StartRaidPanelSettings : BasePanelSettings
    {
        public Player Player;
    }
}