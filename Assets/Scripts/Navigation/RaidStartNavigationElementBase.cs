using UI;
using UnityEngine;
using Zenject;

public class RaidStartNavigationElementBase : NavigationElementBase 
{
    [Inject] private Player _player;
    [Inject] private PopupController _popupController;
    [Inject] private RaidManager _raidManager;
    [Inject] private GameManager _gameManager;
    [Inject] private EquipmentReserveManager _equipmentReserveManager;
    
    public RaidStartNavigationElementBase() 
    {
        ThisNavigationElementType = NavigationElementType.RaidStart; 
    } 
    
    public override bool IsActive() 
    { 
        return _gameManager.CurrentGameState == GameManager.GameState.Lobby; 
    } 

    public override BasePanel CreatePanel(Transform transformParent)
    {
        var prefab = SettingsProvider.Get<PrefabSettings>().GetPanel<StartRaidPanel>();
        var panel = Object.Instantiate(prefab, transformParent);
        panel.Setup(new StartRaidPanelSettings()
        {
            Player = _player,
            PopupController = _popupController,
            RaidManager = _raidManager,
            EquipmentReserveManager = _equipmentReserveManager
        });
        return panel;
    }
}