using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraderPanel : Panel<TraderPanelSettings>
{
    [SerializeField] private TMP_Text _titleTMP;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _second1TMP;
    [SerializeField] private TMP_Text _second2TMP;
    [SerializeField] private TMP_Text _second3TMP;
    [SerializeField] private TMP_Text _button1Text;
    [SerializeField] private TMP_Text _button2Text;
    [SerializeField] private TMP_Text _button3Text;
        
    public override void Setup(TraderPanelSettings settings)
    {
        _titleTMP.text = settings.Text;
        _image.sprite = settings.Image;
        _second1TMP.text = settings.Second1Text;
        _second2TMP.text = settings.Second2Text;
        _second3TMP.text = settings.Second3Text;
        _button1Text.text = settings.Button1Text;
        _button2Text.text = settings.Button2Text;
        _button3Text.text = settings.Button3Text;
    }
}

public class TraderPanelSettings : BasePanelSettings
{
    public string Text;
    public Sprite Image;
    public string Second1Text;
    public string Second2Text;
    public string Second3Text;
    public string Button1Text;
    public string Button2Text;
    public string Button3Text;
}