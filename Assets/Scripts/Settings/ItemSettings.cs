using UnityEngine;

[CreateAssetMenu(menuName = "EscapeFromCity/Items/ItemSettings", fileName = "ItemSettings", order = 0)]
public class ItemSettings : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set;}
    [field: SerializeField] public string DefaultPrice { get; private set;}
    [field: SerializeField] public Rarity Rarity { get; private set;}
    [field: SerializeField] public ItemType ItemType { get; private set;}
    [field: SerializeField] public Sprite Sprite { get; private set;}
    [field: SerializeField] public int ItemSize { get; private set;}
    [field: SerializeField] public int MaxInStack { get; private set;}
    
    public void Init(ItemType enemyType)
    {
        Name = enemyType.ToString();
        ItemType = enemyType;
    }
}