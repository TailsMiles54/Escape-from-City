using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _imageBackground;
    [SerializeField] private Button _button;

    public void Setup(string panelText, Sprite image, Action clickAction)
    {
        _nameField.text = panelText;
        _image.sprite = image;
        _button.onClick.AddListener(clickAction.Invoke);
    }

    public void Activate(bool state)
    {
        _button.interactable = state;
        _imageBackground.SetActive(!state);
    }
}