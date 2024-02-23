using System;
using Settings;
using UnityEngine;

[Serializable]
public class Item
{
    public string Name => ItemType.ToString();
    public ItemType ItemType;
    public int Value;
    public bool Reserved;
    public ItemCategoryType ItemCategoryType => Setting.ItemCategoryType;
    public ItemSettings Setting => SettingsProvider.Get<ItemsList>().GetItem(ItemType);

    public static Item operator +(Item item1, Item item2)
    {
        item1.Value += item2.Value;
        return item1;
    }

    public Item(ItemType itemType, int value = 1)
    {
        ItemType = itemType;
        Value = value;
    }
}