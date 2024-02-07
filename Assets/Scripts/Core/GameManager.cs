using Zenject;

public class GameManager : IInitializable
{
    [Inject] private Player _player;
    
    public GameState CurrentGameState { get; private set; }
    
    public void Initialize()
    {
        _player.SetupFromSave();
    }

    public void ChangeGameState(GameState gameState) => CurrentGameState = gameState;

    public enum GameState
    {
        Lobby = 0,
        Raid = 1
    }
}