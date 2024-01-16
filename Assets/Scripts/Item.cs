public class Item
{
    public ItemType ItemType;
    public int Value;
}

public enum ItemType
{
    //Оружие
    Ak74 = 0,
    M4A1 = 1,
    
    //Еда
    Soda = 2,
    Mayo = 3,
    
    //Патроны
    Ammo545 = 4,
    Ammo556 = 5,
    
    //Мусор
    Tire = 6,
    Battery9V = 7,
    
    //Снаряжение
    Helmet = 8,
    Vest = 9,
    Backpack = 10,
    
    //Ключи
    LabCard = 11
}