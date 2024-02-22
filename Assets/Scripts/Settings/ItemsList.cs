using System.Collections.Generic;
using System.Linq;
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

        public ItemSettings GetItem(ItemType itemType)
        {
            var itemSetting = Items.FirstOrDefault(x => x.ItemType == itemType);

            if (itemSetting == null)
            {
                Debug.LogWarning($"Item setting not found. ItemType: {itemType}");
            }
            
            return itemSetting;
        }
    }
}