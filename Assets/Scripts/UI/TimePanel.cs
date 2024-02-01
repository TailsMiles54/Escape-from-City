using System;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    [SerializeField] private GameObject _imageBackground;
    [SerializeField] private Button _button;

    public void Setup(Action clickAction)
    {
        _button.onClick.AddListener(clickAction.Invoke);
    }

    public void Activate(bool state)
    {
        _imageBackground.SetActive(!state);
    }
}