using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsCached().NonLazy();
        Container.Bind<RaidManager>().AsCached().NonLazy();
    }
}