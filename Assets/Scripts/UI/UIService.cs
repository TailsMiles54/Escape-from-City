using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIService : MonoBehaviour
{
    [SerializeField] private Transform _contentViewTransform;
    [SerializeField] private TMP_Text _moneyTMP;
    [SerializeField] private List<NavigationElement> _bottomNavElements;
    
    [Inject] private Player _player;
    [Inject] private NavigationController _navigationController;

    private List<BasePanel> _panels = new List<BasePanel>();
    
    public void UpdateMoneyText(Item item)
    {
        if(item.ItemType == ItemType.Roubles)
            _moneyTMP.text = $"Money {_player.GetMoney()}";   
    }

    public void UpdateButtonsState(GameManager.GameState gameState)
    {
        foreach (var navigationElement in _bottomNavElements)
        {
            switch (navigationElement.NavigationElementType)
            {
                case NavigationElementType.Profile:
                case NavigationElementType.Inventory:
                case NavigationElementType.Traders:
                case NavigationElementType.Shelter:
                    navigationElement.Activate(gameState != GameManager.GameState.Lobby);
                    break;
            }
        }
    }
    
    public void TabTransition(NavigationElementType navigationElementType)
    {
        for (int i = _panels.Count-1; _panels.Count > 0 && i >= 0 ; i--)
        {
            var child = _panels[i];
            Destroy(child.gameObject);
        }
        
        _panels.Clear();
        
        var childElements = SettingsProvider.Get<NavigationElementSettingsList>().GetChildElements(navigationElementType);

        foreach (var childElement in childElements)
        {
            if (_navigationController.IsActive(childElement))
            {
                var panel = _navigationController.GetPanel(childElement, _contentViewTransform);
                _panels.Add(panel);
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_contentViewTransform.transform);
        Canvas.ForceUpdateCanvases();
    }
}

public enum NavigationElementType
{
    Profile = 0,
    Inventory = 1,
    Raid = 2,
    Traders = 3,
    Shelter = 4,
    
    AllStats = 101,
    Skills = 102,
    PMCStats = 103,
    TrampStats = 104,
    Items = 105,
    NPC = 106,
    ShelterElements = 107,
    RaidStart = 108,
    RaidProcess = 109,
    
    RaidMap = 201,
    RaidTimer = 202,
    RaidActions = 203,
    RaidStats = 304,
}