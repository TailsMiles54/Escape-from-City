using System;
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

    public int RaidTimeSeconds { get; private set; }

    public event Action<int> RaidTimeChanged;
    
    private LocationSettings LocationSettings => SettingsProvider.Get<LocationsList>().GetLocation(CurrentLocation);
    
    public void StartRaid(LocationType selectedLocationType, CharacterType selectedCharacterType, RaidTime selectedDateTime)
    {
        CurrentLocation = selectedLocationType;
        SelectedDateTime = selectedDateTime;
        SelectedCharacterType = selectedCharacterType;
        
        CurrentSubLocation = LocationSettings.GetRandomSubLocation().ThisSubLocationType;
        _gameManager.ChangeGameState(GameManager.GameState.Raid);
        _uiService.UpdateButtonsState(GameManager.GameState.Raid);

        _uiService.TabUpdate();
        SetRaidTime(LocationSettings.LocationTime);
    }

    public void RaidTimeMinus(int seconds)
    {
        var newRaidTime = RaidTimeSeconds - seconds;
        SetRaidTime(newRaidTime);
    }

    private void SetRaidTime(int newSeconds)
    {
        RaidTimeSeconds = newSeconds;
        RaidTimeChanged?.Invoke(RaidTimeSeconds);
        if (RaidTimeSeconds <= 0)
        {
            //raid end
        }
    }
    
    public void EndRaid()
    {
        _gameManager.ChangeGameState(GameManager.GameState.Lobby);
    }
}