using System;
using Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _itemName;

    private Item _item;
    public void Setup(Item item, Action action)
    {
        var itemSetting = SettingsProvider.Get<ItemsList>().GetItem(item.ItemType);
        _item = item;
        _itemName.text = item.ItemType.ToString();
        
        if(itemSetting.Sprite != null)
            _image.sprite = itemSetting.Sprite;
        
        
    }
}