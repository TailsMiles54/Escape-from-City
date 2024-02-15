using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Npc/NpcSetting", fileName = "NpcSetting", order = 0)]
public class NpcSetting : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set;}
    [field: SerializeField] public string Bio { get; private set;}
    [field: SerializeField] public float Price { get; private set;}
    [field: SerializeField] public NpcType NpcType { get; private set;}
    [field: SerializeField] public List<ItemCategoryType> ItemCategory { get; private set;}
    [field: SerializeField] public List<Item> ItemSell { get; private set;}
    [field: SerializeField] public Sprite Sprite { get; private set;}

    public void Init(NpcType npcType)
    {
        Name = npcType.ToString();
        NpcType = npcType;
        Price = 1;
    }
}