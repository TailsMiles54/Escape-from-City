using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "EscapeFromCity/Items/ItemsList", fileName = "ItemsList", order = 0)]
    public class ItemsList : ScriptableObject
    {
        [field: SerializeField] public List<ItemSettings> Items { get; private set;}

        public void AddItem(ItemSettings itemSetting)
        {
            Items.Add(itemSetting);
        }
    }
}