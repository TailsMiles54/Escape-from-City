using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _imageBackground;
    [SerializeField] private Button _button;

    public void Setup(string characterName, Sprite image, Action clickAction)
    {
        _nameField.text = characterName;
        _image.sprite = image;
        _button.onClick.AddListener(clickAction.Invoke);
    }

    public void Activate(bool state)
    {
        _imageBackground.SetActive(!state);
    }
}