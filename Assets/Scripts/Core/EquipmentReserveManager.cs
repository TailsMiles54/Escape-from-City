using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class EquipmentReserveManager : IInitializable
{
    [Inject] private SaveManager _saveManager;
    [Inject] private UIService _uiService;
    [Inject] private Player _player;

    
    //todo убрать отсюда чарактера и у него чисто флагом в инвентаре помечать
    public Dictionary<CharacterType, ReservedItems> ReservedItems { get; private set; }
    
    public void Initialize()
    {
        _saveManager.LoadReservedItemsData(out var reservedItemsMap);

        ReservedItems = reservedItemsMap;
        Debug.Log(ReservedItems[CharacterType.Character].Items.Count);
        
        if(reservedItemsMap[CharacterType.Tramp].Items.All(x => x.Item == null))
            GenerateNewEquipmentForTramp();
    }

    public void SelectItem(Item selectedItem)
    {
        var characterItem = ReservedItems[CharacterType.Character].Items.First(x => x.ItemCategoryType == selectedItem.ItemCategoryType);

        var item = characterItem.Item;
        
        if(characterItem.Item != null)
            item.Reserved = false;
            
        selectedItem.Reserved = true;
        characterItem.Item = selectedItem;
        SaveReservedItems();
        Debug.Log(ReservedItems[CharacterType.Character].Items.Count);
    }

    public void GenerateNewEquipmentForTramp()
    {
        var trampRandomSettings = SettingsProvider.Get<TrampItemsTiers>();
        var trampItems = ReservedItems[CharacterType.Tramp];
        trampItems.Items.First(x => x.ItemCategoryType == ItemCategoryType.Weapon).Item = trampRandomSettings.GetRandomWeapon(_player);
        trampItems.Items.First(x => x.ItemCategoryType == ItemCategoryType.Helmet).Item = trampRandomSettings.GetRandomHelmet(_player);
        trampItems.Items.First(x => x.ItemCategoryType == ItemCategoryType.Backpack).Item = trampRandomSettings.GetRandomBackpack(_player);
        trampItems.Items.First(x => x.ItemCategoryType == ItemCategoryType.ArmorVests).Item = trampRandomSettings.GetRandomBulletproof(_player);
        
        SaveReservedItems();
        Debug.Log(ReservedItems[CharacterType.Character].Items.Count);
    }

    public void SaveReservedItems()
    {
        _saveManager.SaveReservedItems(ReservedItems);
        Debug.Log(ReservedItems[CharacterType.Character].Items.Count);
    }
}

public class ReservedItems
{
    public List<ReserveItem> Items = new List<ReserveItem>()
    {
        new ReserveItem(ItemCategoryType.Weapon),
        new ReserveItem(ItemCategoryType.Helmet),
        new ReserveItem(ItemCategoryType.Backpack),
        new ReserveItem(ItemCategoryType.ArmorVests),
    };

    public List<Item> ItemsInBackpack = new List<Item>();

    public void Clear()
    {
        Items = new List<ReserveItem>()
        {
            new ReserveItem(ItemCategoryType.Weapon),
            new ReserveItem(ItemCategoryType.Helmet),
            new ReserveItem(ItemCategoryType.Backpack),
            new ReserveItem(ItemCategoryType.ArmorVests),
        };
        ItemsInBackpack = new List<Item>();
    }
}

public class ReserveItem
{
    public ItemCategoryType ItemCategoryType { get; private set; }
    public Item Item;

    public ReserveItem(ItemCategoryType category)
    {
        ItemCategoryType = category;
    }
}