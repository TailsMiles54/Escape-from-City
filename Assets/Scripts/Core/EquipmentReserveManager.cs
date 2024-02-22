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

    public Dictionary<CharacterType, ReservedItems> ReservedItems { get; private set; } =
        new Dictionary<CharacterType, ReservedItems>()
        {
            { CharacterType.Character , new ReservedItems()},
            { CharacterType.Tramp , new ReservedItems()},
        };
    
    public void Initialize()
    {
        GenerateNewEquipmentForTramp();
    }

    public void SelectItem(Item item)
    {
        var characterItems = ReservedItems[CharacterType.Character];
        switch (item.Setting.ItemCategoryType)
        {
            case ItemCategoryType.Weapon:
                if(characterItems.FirstWeapon != null)
                    characterItems.FirstWeapon.Reserved = false;
                
                item.Reserved = true;
                characterItems.FirstWeapon = item;
                break;
            case ItemCategoryType.Helmet:
                if(characterItems.Helmet != null)
                    characterItems.Helmet.Reserved = false;
                
                item.Reserved = true;
                characterItems.Helmet = item;
                break;
            case ItemCategoryType.Backpack:
                if(characterItems.Backpack != null)
                    characterItems.Backpack.Reserved = false;
                
                item.Reserved = true;
                characterItems.Backpack = item;
                break;
            case ItemCategoryType.ArmorVests:
                if(characterItems.ArmorVests != null)
                    characterItems.ArmorVests.Reserved = false;
                
                item.Reserved = true;
                characterItems.ArmorVests = item;
                break;
        }

    }

    public void GenerateNewEquipmentForTramp()
    {
        var trampRandomSettings = SettingsProvider.Get<TrampItemsTiers>();
        var trampItems = ReservedItems[CharacterType.Tramp];
        trampItems.FirstWeapon = trampRandomSettings.GetRandomWeapon(_player);
        trampItems.Helmet = trampRandomSettings.GetRandomHelmet(_player);
        trampItems.Backpack = trampRandomSettings.GetRandomBackpack(_player);
        trampItems.ArmorVests = trampRandomSettings.GetRandomBulletproof(_player);
    }
}

public class ReservedItems
{
    public Item FirstWeapon;
    public Item Helmet;
    public Item Backpack;
    public Item ArmorVests;

    public List<Item> ItemsInBackpack = new List<Item>();

    public void Clear()
    {
        FirstWeapon = null;
        Helmet = null;
        Backpack = null;
        ArmorVests = null;
        ItemsInBackpack = new List<Item>();
    }
}