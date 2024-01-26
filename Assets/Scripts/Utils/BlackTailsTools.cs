using System;
using System.IO;
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
            var itemSetting = itemType is ItemType.Ak74 or ItemType.M4A1  
                ? ScriptableObject.CreateInstance<WeaponSetting>()
                : ScriptableObject.CreateInstance<ItemSettings>();
                
            itemSetting.Init(itemType);
            AssetDatabase.CreateAsset(itemSetting, $"Assets/Settings/Items/{itemType.ToString()}.asset");
            itemsList.AddItem(itemSetting);

            Debug.Log($"{itemType.ToString()}.asset created");
        }
    }
    
    [MenuItem("BlackTailsTools/Очистка сейвов")]
    static void DeleteSaveFiles()
    {
        string savePath = Application.persistentDataPath;
        string[] saveFiles = Directory.GetFiles(savePath);

        foreach (string file in saveFiles)
        {
            File.Delete(file);
        }

        Debug.Log("Save files deleted successfully.");
    }

    
    [MenuItem("BlackTailsTools/Очистка PlayerPrefs")]
    static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs cleared successfully.");
    }
}
