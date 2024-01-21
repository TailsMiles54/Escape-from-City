using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class StatsPanel : Panel<StatsPanelSettings>
    {
        [SerializeField] private TMP_Text _titleTMP;
        [SerializeField] private Transform _parentForContent;
        
        public override void Setup(StatsPanelSettings settings)
        {
            _titleTMP.text = settings.TitleText;

            foreach (var element in settings.StatsElements)
            {
                var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<DoubleTextPanel>();
                var elementObject = Instantiate(prefab, _parentForContent.transform);
                elementObject.Setup(new DoubleTextPanelSettings()
                {
                    Text = element.Item1,
                    SecondText = element.Item2
                });
            }
        }
    }

    public class StatsPanelSettings : BasePanelSettings
    {
        public string TitleText;
        public List<(string, string)> StatsElements;
    }
}