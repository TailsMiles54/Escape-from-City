using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Player : IInitializable
{
    [Inject] private SaveManager _saveManager;
    
    public string Name {get; private set;}
    public int Level {get; private set;}
    public int Exp {get; private set;}
    public Inventory Inventory { get; private set; } = new Inventory();
    public List<Skill> Skills {get; private set;}
    public List<Parameter> Parameters {get; private set;}
    public int GetMoney() => Inventory.Items.First(x => x.ItemType == ItemType.Money).Value;

    public void ChangeNickname(string newNickname)
    {
        Name = newNickname;
        _saveManager.SavePlayerData();
    }

    public void SetupFromSave()
    {
        var saveData = _saveManager.LoadPlayerData();
        Name = saveData.Name;
        Level = saveData.Level;
        Exp = saveData.Exp;
        Skills = saveData.Skills;
        Parameters = saveData.Parameters;

        if (saveData == new PlayerSaveData())
        {
            _saveManager.SavePlayerData();
        }
    }

    public void Initialize()
    {
        SetupFromSave();
    }
}

public class Inventory
{
    public List<Item> Items { get; private set; } = new List<Item>();

    public event Action<Item> ItemAddedEvent; 
    
    public void AddItem(Item item)
    {
        Items.Add(item);
        ItemAddedEvent?.Invoke(item);
    }
}