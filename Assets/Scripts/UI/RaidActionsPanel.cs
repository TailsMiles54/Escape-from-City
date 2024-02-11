using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class RaidActionsPanel : Panel<RaidActionsPanelSettings>
    {
        [SerializeField] private Transform _actionsParent;
        public override void Setup(RaidActionsPanelSettings settings)
        {
            var actionItemPrefab = SettingsProvider.Get<PrefabSettings>().ActionItem;
            foreach (var actionSetting in settings.ActionSettings)
            {
                var actionItem = Instantiate(actionItemPrefab, _actionsParent);
                actionItem.Setup(actionSetting);
            }
        }
    }
    public class RaidActionsPanelSettings : BasePanelSettings
    {
        public List<ActionSetting> ActionSettings { get; set; }
    }
}