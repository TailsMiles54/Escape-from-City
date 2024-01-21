using TMPro;
using UnityEngine;

namespace UI
{
    public class SingleTextPanel : Panel<SingleTextPanelSettings>
    {
        [SerializeField] private TMP_Text _titleTMP;
        
        public override void Setup(SingleTextPanelSettings settings)
        {
            _titleTMP.text = settings.Text;
        }
    }

    public class SingleTextPanelSettings : BasePanelSettings
    {
        public string Text;
    }
}