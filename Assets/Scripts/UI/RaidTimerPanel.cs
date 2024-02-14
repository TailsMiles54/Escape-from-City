using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RaidTimerPanel : Panel<RaidTimerPanelSettings>
    {
        [SerializeField] private TMP_Text _timerText; 
        private RaidManager _raidManager;
        
        public override void Setup(RaidTimerPanelSettings settings)
        {
            _raidManager = settings.RaidManager;
            _raidManager.RaidTimeChanged += UpdateTimer;
        }

        public void UpdateTimer(int seconds)
        {
            _timerText.text = TimeSpan.FromSeconds(seconds).TotalMinutes.ToString();
        }

        private void OnDestroy()
        {
            _raidManager.RaidTimeChanged -= UpdateTimer;
        }
    }
    public class RaidTimerPanelSettings : BasePanelSettings
    {
        public RaidManager RaidManager;
    }
}