using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    
    public override void InstallBindings()
    {
        // var playerInstance = Container
        //     .InstantiatePrefabForComponent<Player>(_player, transform.position, quaternion.identity, null);

        Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
        Container.QueueForInject(_player);
    }
}