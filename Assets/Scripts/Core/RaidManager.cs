using Settings;
using Zenject;

public class RaidManager
{
    [Inject] private GameManager _gameManager;
    [Inject] private UIService _uiService;
    
    public LocationType CurrentLocation { get; private set; }
    public SubLocationType CurrentSubLocation { get; private set; }
    public RaidTime SelectedDateTime { get; private set; }
    public CharacterType SelectedCharacterType { get; private set; }
    private LocationSettings LocationSettings => SettingsProvider.Get<LocationsList>().GetLocation(CurrentLocation);
    
    public void StartRaid(LocationType selectedLocationType, CharacterType selectedCharacterType, RaidTime selectedDateTime)
    {
        CurrentLocation = selectedLocationType;
        SelectedDateTime = selectedDateTime;
        SelectedCharacterType = selectedCharacterType;
        
        CurrentSubLocation = LocationSettings.GetRandomSubLocation().ThisSubLocationType;
        _gameManager.ChangeGameState(GameManager.GameState.Raid);
        _uiService.UpdateButtonsState(GameManager.GameState.Raid);
    }
    
    public void EndRaid()
    {
        _gameManager.ChangeGameState(GameManager.GameState.Lobby);
    }
}