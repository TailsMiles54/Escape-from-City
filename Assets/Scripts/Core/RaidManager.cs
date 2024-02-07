using Settings;
using Zenject;

public class RaidManager
{
    [Inject] private GameManager _gameManager;
    
    public LocationType CurrentLocation { get; private set; }
    public SubLocationType CurrentSubLocation { get; private set; }
    private LocationSettings LocationSettings => SettingsProvider.Get<LocationsList>().GetLocation(CurrentLocation);
    
    public void StartRaid(LocationType locationType)
    {
        CurrentLocation = locationType;
        CurrentSubLocation = LocationSettings.GetRandomSubLocation().ThisSubLocationType;
        _gameManager.ChangeGameState(GameManager.GameState.Raid);
    }
    
    public void EndRaid()
    {
        _gameManager.ChangeGameState(GameManager.GameState.Lobby);
    }
}