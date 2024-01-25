using System;

[Serializable]
public class Item
{
    public ItemType ItemType;
    public int Value;
}

[Flags]
public enum ItemType
{
    None = 0,
    
    Weapons = Ak74 | M4A1,
    //Оружие
    Ak74 = 701,
    M4A1 = 702,
    
    Eat = Soda | Mayo | Clickers,
    //Еда
    Soda = 101,
    Mayo = 102,
    Clickers = 104,
    
    Ammo = Ammo545 | Ammo556,
    //Патроны
    Ammo545 = 201,
    Ammo556 = 202,
    
    Trash = Tire | Battery9V,
    //Мусор
    Tire = 301,
    Battery9V = 302,
    
    Equipment = HelmetModul3M | VestModul3M | Backpack,
    //Снаряжение
    HelmetModul3M = 401,
    VestModul3M = 402,
    Backpack = 403,
    
    Keys = LabCard,
    //Ключи
    LabCard = 501,
    
    Money = Roubles,
    //Деньги
    Roubles = 601,
    
    Medicine = AI | AI2 | Bandage | Tourniquet,
    //Медицина
    AI = 701,
    AI2 = 702,
    Bandage = 703,
    Tourniquet = 704,
}