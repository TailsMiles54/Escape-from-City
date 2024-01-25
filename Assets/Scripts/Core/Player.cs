using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    private string Name;
    
    private int Level;
    private int Exp;
    public Inventory Inventory { get; private set; } = new Inventory();
    
    private List<Skill> _skills;
    private List<Parameter> _parameters;

    public int GetMoney() => Inventory.Items.First(x => x.ItemType == ItemType.Money).Value;
    
    public void Test(string text)
    {
        Debug.Log(text);
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