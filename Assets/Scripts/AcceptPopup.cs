using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AcceptPopup : Popup<AcceptPopupSetting>
{
    [SerializeField] private TMP_Text _titleTMP;
    [SerializeField] private TMP_Text _contentTMP;
    [SerializeField] private Image _image;
    [SerializeField] private Button _buttonAccept;
    [SerializeField] private Button _buttonNotAccept;
    public override void Setup(AcceptPopupSetting setting)
    {
        _titleTMP.SetText(setting.Title);
        _contentTMP.SetText(setting.Content);
        _image.sprite = setting.Icon;
        _buttonAccept.onClick.AddListener(setting.AcceptItemAction.Invoke);
        _buttonNotAccept.onClick.AddListener(setting.NotAcceptItemAction.Invoke);
    }
}

public class AcceptPopupSetting : BasePopupSettings
{
    public string Title;
    public string Content;
    public Sprite Icon;
    public Action AcceptItemAction;
    public Action NotAcceptItemAction;
} 