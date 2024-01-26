using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsCached().NonLazy();
        Container.QueueForInject(_gameManager);
    }
}