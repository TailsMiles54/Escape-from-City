using System;
using Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _imageBackground;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _infoField;

    public ItemCategoryType ItemCategoryType { get; private set; }
    
    public void Setup(string panelText, ItemCategoryType categoryType, Sprite image, Action clickAction)
    {
        ItemCategoryType = categoryType;
        _nameField.text = panelText;
        _image.sprite = image;
        _button.onClick.AddListener(clickAction.Invoke);
    }

    public void Activate(bool state)
    {
        _button.interactable = state;
        _imageBackground.SetActive(!state);
    }

    public void SetItem(ItemType itemType)
    {
        _infoField.text = itemType.ToString();
        _image.sprite = SettingsProvider.Get<ItemsList>().GetItem(itemType).Sprite;
    }

    public void SetEmpty()
    {
        _infoField.text = "";
        _image.sprite = SettingsProvider.Get<PrefabSettings>().TestImage;
    }
}