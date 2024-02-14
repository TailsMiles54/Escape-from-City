using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleTMP;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _second1TMP;
    [SerializeField] private TMP_Text _button1Text;
    [SerializeField] private TMP_Text _button2Text;
    [SerializeField] private TMP_Text _button3Text;
        
    public void Setup(NpcSetting settings)
    {
        _titleTMP.text = settings.Name;
        _image.sprite = settings.Sprite;
        _second1TMP.text = settings.Bio;
        _button1Text.text = "Buy";
        _button2Text.text = "Quests";
        _button3Text.text = "Sell";
    }
}

public class NpcPanelSettings : BasePanelSettings
{
}