using System;
using Settings;

[Serializable]
public class Item
{
    public ItemType ItemType;
    public int Value;
    public ItemCategoryType ItemCategoryType => SettingsProvider.Get<ItemsList>().GetItem(ItemType).ItemCategoryType;

    public static Item operator +(Item item1, Item item2)
    {
        item1.Value += item2.Value;
        return item1;
    } 
}