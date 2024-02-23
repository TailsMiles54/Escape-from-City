using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

public class SaveManager
{
    [Inject] private Player _player;
    [Inject] private ShelterManager _shelterManager;
    
    public void SavePlayerData()
    {
        var data = new PlayerSaveData()
        {
            Name = _player.Name,
            Level = _player.Level,
            Exp = _player.Exp,
            Skills = _player.Skills,
            Parameters = _player.Parameters,
            Inventory = _player.Inventory
        };
        
        SaveData(data, "PlayerData.json");
    }

    public bool LoadPlayerData(out PlayerSaveData playerSaveData)
    {
        string path = Path.Combine(Application.persistentDataPath, "PlayerData.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerSaveData = JsonConvert.DeserializeObject<PlayerSaveData>(json);
            return true;
        }
        else
        {
            playerSaveData = new PlayerSaveData();
            return false;
        }
    }
    
    public static void SaveData<T>(T data, string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, json);
    }

    public void SaveShelterData(Dictionary<ShelterUpgradeType, int> shelterUpgrades)
    {
        SaveData(shelterUpgrades, "ShelterData.json");
    }

    public void LoadShelterData(out Dictionary<ShelterUpgradeType, int> shelterUpgrades)
    {
        string path = Path.Combine(Application.persistentDataPath, "ShelterData.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            shelterUpgrades = JsonConvert.DeserializeObject<Dictionary<ShelterUpgradeType, int>>(json);
        }
        else
        {
            shelterUpgrades = new Dictionary<ShelterUpgradeType, int>();
        }
    }

    public void SaveReservedItems(Dictionary<CharacterType, ReservedItems> reservedItemsMap)
    {
        SaveData(reservedItemsMap, "ReservedItems.json");
    }

    public void LoadReservedItemsData(out Dictionary<CharacterType, ReservedItems> reservedItemsMap)
    {
        string path = Path.Combine(Application.persistentDataPath, "ReservedItems.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            reservedItemsMap = JsonConvert.DeserializeObject<Dictionary<CharacterType, ReservedItems>>(json);
        }
        else
        {
            reservedItemsMap = new Dictionary<CharacterType, ReservedItems>()
            {
                { CharacterType.Character, new ReservedItems() },
                { CharacterType.Tramp, new ReservedItems() },
            };
        }
    }
}