using UnityEngine;

namespace UI
{
    public class RaidMapPanel : Panel<RaidMapPanelSettings>
    {
        [SerializeField] private Transform _mapParent;
        
        public override void Setup(RaidMapPanelSettings settings)
        {
            var map = Instantiate(settings.MapItem, _mapParent);
        }
    }
    
    public class RaidMapPanelSettings : BasePanelSettings
    {
        public MapItem MapItem;
    }
}