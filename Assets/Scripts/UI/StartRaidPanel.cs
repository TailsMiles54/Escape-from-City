using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartRaidPanel : Panel<StartRaidPanelSettings>
    {
        [SerializeField] private TMP_Text _titleTMP;
        [SerializeField] private TMP_Text _secondTMP;
        
        public override void Setup(StartRaidPanelSettings settings)
        {
            _titleTMP.text = settings.Text;
            _secondTMP.text = settings.SecondText;
        }
    }

    public class StartRaidPanelSettings : BasePanelSettings
    {
        public string Text;
        public string SecondText;
    }
}

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _image;

    public void Setup(string name, Sprite image)
    {
        _nameField.text = name;
        _image.sprite = image;
    }
}