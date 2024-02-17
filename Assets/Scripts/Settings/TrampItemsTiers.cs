using System;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

[CreateAssetMenu(menuName = "EscapeFromCity/Tramp/TrampItemsTiers", fileName = "TrampItemsTiers", order = 0)]
public class TrampItemsTiers : ScriptableObject
{
    [Tab("Weapons")] [SerializeField] List<TrampItemTier> _weaponsTiers;
    [Tab("Equipment")] 
    [SerializeField] List<TrampItemTier> _bulletproofVestTiers;
    [SerializeField] List<TrampItemTier> _helmetTiers;
    [SerializeField] List<TrampItemTier> _backpackTiers;
    [Tab("Trash")] [SerializeField] List<TrampItemTier> _trashTiers;
    
    public List<TrampItemTier> WeaponsTiers => _weaponsTiers;
    public List<TrampItemTier> BulletproofVestTiers => _bulletproofVestTiers;
    public List<TrampItemTier> HelmetTiers => _helmetTiers;
    public List<TrampItemTier> BackpackTiers => _backpackTiers;
    public List<TrampItemTier> TrashTiers => _trashTiers;
}

[Serializable]
public class TrampItemTier
{
    public int MinLevel;
    public List<ItemSpawnChance> Items;
}

[Serializable]
public class ItemSpawnChance
{
    public ItemType ItemType;
    public bool RandomChance;
    //При рандоме нужно искать доступный предмет с макс шансом
    public float SpawnChance;
}