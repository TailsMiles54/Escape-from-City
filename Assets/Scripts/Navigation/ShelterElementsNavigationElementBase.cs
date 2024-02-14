using System;
using System.Linq;
using UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class ShelterElementsNavigationElementBase : NavigationElementBase
{
    [Inject] private ShelterManager _shelterManager;
    [Inject] private GameManager _gameManager;
    public ShelterElementsNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.ShelterElements; 
    } 
    
    public override bool IsActive() 
    { 
        return _gameManager.CurrentGameState == GameManager.GameState.Lobby; 
    }

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<ShelterPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new ShelterPanelSettings()
        {
            ShelterManager = _shelterManager
        });
        return panel;
    }
}