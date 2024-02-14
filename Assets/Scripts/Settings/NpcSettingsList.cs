using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Npc/NpcSettingsList", fileName = "NpcSettingsList", order = 0)]
public class NpcSettingsList : ScriptableObject
{
    [field: SerializeField] public List<NpcSetting> NpcSettings { get; private set;}

    public NpcSetting GetNpcSetting(NpcType npcType) => NpcSettings.First(x => x.NpcType == npcType);

    public void AddItem(NpcSetting npcSetting)
    {
        NpcSettings.Add(npcSetting);
    }
}