using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Player
{
    [Inject] private SaveManager _saveManager;
    
    public string Name {get; private set;}
    public int Level {get; private set;}
    public int Exp {get; private set;}
    public Inventory Inventory { get; private set; } = new Inventory();
    public List<Skill> Skills {get; private set;}
    public List<Parameter> Parameters {get; private set;}
    public int GetMoney() => Inventory.Items.First(x => x.ItemType == ItemType.Roubles).Value;

    public void ChangeNickname(string newNickname)
    {
        Name = newNickname;
        _saveManager.SavePlayerData();
    }

    public void SetupFromSave()
    {
        var saveResult = _saveManager.LoadPlayerData(out PlayerSaveData playerSaveData);
        
        Name = playerSaveData.Name;
        Level = playerSaveData.Level;
        Exp = playerSaveData.Exp;
        Skills = playerSaveData.Skills;
        Parameters = playerSaveData.Parameters;
        Inventory = playerSaveData.Inventory;
        
        if(!saveResult)
        {
            Inventory.StartSetup();
            _saveManager.SavePlayerData();
        }
    }
}

[Serializable]
public class Inventory
{
    public int AvailableSlots;
    public List<Item> Items { get; private set; } = new List<Item>();

    public event Action<Item> ItemAddedEvent; 
    public event Action InventoryUpdated; 
    
    public void AddItem(Item item)
    {
        Items.Add(item);
        ItemAddedEvent?.Invoke(item);
        InventoryUpdated?.Invoke();
    }
    
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        InventoryUpdated?.Invoke();
    }

    public void StartSetup()
    {
        var startSettings = SettingsProvider.Get<StartPlayerSettings>();
        AvailableSlots = startSettings.StartedInventorySize;
        Items = startSettings.StartItems;
    }
}