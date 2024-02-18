using System.Collections.Generic;
using System.Linq;
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