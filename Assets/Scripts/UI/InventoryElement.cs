using Settings;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Item _item;
    public void Setup(Item item)
    {
        var itemSetting = SettingsProvider.Get<ItemsList>().GetItem(item.ItemType);
        _item = item;
        _image.sprite = itemSetting.Sprite;
    }
}