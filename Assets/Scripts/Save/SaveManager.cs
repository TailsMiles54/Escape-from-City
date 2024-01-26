using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

public class SaveManager
{
    [Inject] private Player _player;
    
    public void SavePlayerData()
    {
        var data = new PlayerSaveData()
        {
            Name = _player.Name,
            Level = _player.Level,
            Exp = _player.Exp,
            Skills = _player.Skills,
            Parameters = _player.Parameters,
        };
        
        SaveData(data, "PlayerData.json");
    }

    public PlayerSaveData LoadPlayerData()
    {
        string path = Path.Combine(Application.persistentDataPath, "PlayerData.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var saveData = JsonConvert.DeserializeObject<PlayerSaveData>(json);
            return saveData;
        }
        else
        {
            return new PlayerSaveData();
        }
    }
    
    public static void SaveData<T>(T data, string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, json);
    }
}