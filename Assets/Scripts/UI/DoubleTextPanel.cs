using TMPro;
using UnityEngine;

namespace UI
{
    public class DoubleTextPanel : Panel<DoubleTextPanelSettings>
    {
        [SerializeField] private TMP_Text _titleTMP;
        [SerializeField] private TMP_Text _secondTMP;
        
        public override void Setup(DoubleTextPanelSettings settings)
        {
            _titleTMP.text = settings.Text;
            _secondTMP.text = settings.SecondText;
        }
    }

    public class DoubleTextPanelSettings : BasePanelSettings
    {
        public string Text;
        public string SecondText;
    }
}