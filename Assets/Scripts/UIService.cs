using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UIService : MonoBehaviour
{
    [SerializeField] private Transform _contentViewTransform;
    [SerializeField] private TMP_Text _moneyTMP;
    
    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _player.Inventory.ItemAddedEvent += UpdateMoneyText;
    }

    public void UpdateMoneyText(Item item)
    {
        if(item.ItemType == ItemType.Roubles)
            _moneyTMP.text = $"Money {_player.GetMoney()}";   
    }
    
    public void TabTransition(NavigationElementType navigationElementType)
    {
        for (int i = 0; i < _contentViewTransform.transform.childCount; i++)
        {
            var child = _contentViewTransform.transform.GetChild(0);
            Destroy(child);
        }

        var childElements = SettingsProvider.Get<NavigationElementSettingsList>().GetChildElements(navigationElementType);

        foreach (var childElement in childElements)
        {
            // проверять доступность элементов
        }
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
    PMCstats = 103,
    TrampStats = 104,
    Items = 105,
    NPC = 106,
    ShelterElements = 107,
    RaidStart = 108,
    RaidProcess = 109
}