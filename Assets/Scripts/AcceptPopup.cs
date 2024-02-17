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
    [SerializeField] private TMP_Text _buttonAcceptTMP;
    [SerializeField] private TMP_Text _buttonNotAcceptTMP;
    public override void Setup(AcceptPopupSetting setting)
    {
        _titleTMP.SetText(setting.Title);
        _contentTMP.SetText(setting.Content);
        _image.sprite = setting.Icon;
        _buttonAccept.onClick.AddListener(setting.AcceptItemAction.Invoke);
        _buttonNotAccept.onClick.AddListener(setting.NotAcceptItemAction.Invoke);
        
        _buttonAcceptTMP.SetText("Accept");
        _buttonNotAcceptTMP.SetText("Decline");
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