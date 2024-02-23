using System;
using Newtonsoft.Json;
using Settings;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemType ItemType;
    public int Value;
    public bool Reserved;
    [JsonIgnore] public ItemCategoryType ItemCategoryType => Setting.ItemCategoryType;
    [JsonIgnore] public ItemSettings Setting => SettingsProvider.Get<ItemsList>().GetItem(ItemType);

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