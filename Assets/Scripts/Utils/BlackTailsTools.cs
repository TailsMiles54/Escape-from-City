using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Settings;
using UnityEditor;
using UnityEngine;

public class BlackTailsTools : MonoBehaviour
{
    [MenuItem("BlackTailsTools/Создать настройки предметов")]
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
    
    [MenuItem("BlackTailsTools/Создать настройки локаций")]
    static void CreateLocations()
    {
        var locationsList = SettingsProvider.Get<LocationsList>();
        var locationsSettings = locationsList.Locations;
        var addedLocation = locationsSettings.Select(x => x.LocationType);
        var locationTypes = Enum.GetValues(typeof(LocationType)).Cast<LocationType>().ToList();
        var newLocations = locationTypes.Except(addedLocation).ToList();
        
        foreach (var newLocation in newLocations)
        {
            var locationSettings = ScriptableObject.CreateInstance<LocationSettings>();
                
            locationSettings.Init(newLocation);
            AssetDatabase.CreateAsset(locationSettings, $"Assets/Settings/Locations/{newLocation.ToString()}.asset");
            locationsList.AddItem(locationSettings);

            Debug.Log($"{newLocation.ToString()}.asset created");
        }
    }
    
    [MenuItem("BlackTailsTools/Создать настройки сублокаций")]
    static void CreateSubLocations()
    {
        //todo: нужно переписать пусть создания сублокаций
        
        // var locationTypes = Enum.GetValues(typeof(LocationType)).Cast<LocationType>().ToList();
        //
        // List<SubLocationType> usedSubLocationTypes = new List<SubLocationType>();
        // foreach (var locationType in locationTypes)
        // {
        //     var locationSettings = SettingsProvider.Get<LocationsList>().GetLocation(locationType);
        //     usedSubLocationTypes.AddRange(locationSettings.SubLocationSettings.Select(x => x.ThisSubLocationType));
        // }
        //
        // var subLocationTypes = Enum.GetValues(typeof(SubLocationType)).Cast<SubLocationType>().ToList();
        // var newLocations = subLocationTypes.Except(usedSubLocationTypes).ToList();
        //
        // foreach (var newLocation in newLocations)
        // {
        //     var locationSettings = ScriptableObject.CreateInstance<SubLocationSettings>();
        //         
        //     locationSettings.Init(newLocation);
        //     AssetDatabase.CreateAsset(locationSettings, $"Assets/Settings/SubLocations/{newLocation.ToString()}.asset");
        //
        //     Debug.Log($"{newLocation.ToString()}.asset created");
        // }
    }
}
