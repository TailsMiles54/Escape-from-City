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
            npc.Setup(npcSetting);
        }
    }
}