using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class NavigationController : IInitializable
{
    [Inject] private Player _player;
    [Inject] private PopupController _popupController;
    
    [Inject] private DiContainer _diContainer;
    
    private List<NavigationElementBase> _navigationElements;

    public void Initialize()
    {
        _navigationElements = new List<NavigationElementBase>()
        {
            (AllStatsNavigationElementBase)_diContainer.Instantiate(typeof(AllStatsNavigationElementBase)),
            (SkillsNavigationElementBase)_diContainer.Instantiate(typeof(SkillsNavigationElementBase)),
            (PMCStatsNavigationElementBase)_diContainer.Instantiate(typeof(PMCStatsNavigationElementBase)),
            (TrampStatsNavigationElementBase)_diContainer.Instantiate(typeof(TrampStatsNavigationElementBase)),
            (ItemsNavigationElementBase)_diContainer.Instantiate(typeof(ItemsNavigationElementBase)),
            (NpcNavigationElementBase)_diContainer.Instantiate(typeof(NpcNavigationElementBase)),
            (ShelterElementsNavigationElementBase)_diContainer.Instantiate(typeof(ShelterElementsNavigationElementBase)),
            (RaidStartNavigationElementBase)_diContainer.Instantiate(typeof(RaidStartNavigationElementBase)),
            (RaidProcessNavigationElementBase)_diContainer.Instantiate(typeof(RaidProcessNavigationElementBase)),
            
            (RaidMapNavigationElementBase)_diContainer.Instantiate(typeof(RaidMapNavigationElementBase)),
            (RaidProcessNavigationElementBase)_diContainer.Instantiate(typeof(RaidProcessNavigationElementBase)),
            (RaidStatsNavigationElementBase)_diContainer.Instantiate(typeof(RaidStatsNavigationElementBase)),
            (RaidTimerNavigationElementBase)_diContainer.Instantiate(typeof(RaidTimerNavigationElementBase)),
        };
    }
    
    public bool IsActive(NavigationElementType navigationElementType)
    {
        if (_navigationElements.All(x => x.ThisNavigationElementType != navigationElementType))
        {
            Debug.LogWarning($"NavigationController not contain BaseElement for {navigationElementType}");
            return false;
        }
        
        return _navigationElements
            .First(x => x.ThisNavigationElementType == navigationElementType).IsActive();
    }

    public BasePanel GetPanel(NavigationElementType navigationElementType, Transform transformParent)
    {
        return _navigationElements
            .First(x => x.ThisNavigationElementType == navigationElementType).CreatePanel(transformParent);
    }
}