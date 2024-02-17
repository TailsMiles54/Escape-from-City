using UnityEngine;

public class NpcPanel : Panel<NpcPanelSettings>
{
    [SerializeField] private Transform _npcParent;
        
    public override void Setup(NpcPanelSettings settings)
    {
        var npcSettings = SettingsProvider.Get<NpcSettingsList>().NpcSettings;
        var npcItemPrefab = SettingsProvider.Get<PrefabSettings>().ItemNpcPrefab;
        foreach (var npcSetting in npcSettings)
        {
            var npc = Instantiate(npcItemPrefab, _npcParent);
            npc.Setup(npcSetting, settings.Player, settings.PopupController);
        }
    }
}

public class NpcPanelSettings : BasePanelSettings
{
    public Player Player;
    public PopupController PopupController;
}