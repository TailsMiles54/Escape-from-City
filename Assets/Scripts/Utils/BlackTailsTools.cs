using System;
using System.Linq;
using Settings;
using UnityEditor;
using UnityEngine;

public class BlackTailsTools : MonoBehaviour
{
    [MenuItem("BlackTailsTools/Создать объекты противников")]
    static void CreateEnemies()
    {
        var itemsList = SettingsProvider.Get<ItemsList>();
        var itemsSettings = itemsList.Items;
        var addedItems = itemsSettings.Select(x => x.ItemType);
        var itemTypes = Enum.GetValues(typeof(ItemType)).Cast<ItemType>().ToList();
        var newItems = itemTypes.Except(addedItems).ToList();
        
        foreach (var itemType in newItems)
        {
            if(itemType is ItemType.Equipment or ItemType.Ammo or ItemType.Weapons or ItemType.Trash or ItemType.Money or ItemType.Eat or ItemType.None)
                continue;
            
            var itemSetting = itemType == ItemType.Weapons
                ? ScriptableObject.CreateInstance<WeaponSetting>()
                : ScriptableObject.CreateInstance<ItemSettings>();
                
            itemSetting.Init(itemType);
            AssetDatabase.CreateAsset(itemSetting, $"Assets/Settings/Items/{itemType.ToString()}.asset");
            itemsList.AddItem(itemSetting);

            Debug.Log($"{itemType.ToString()}.asset created");
        }
    }
}
