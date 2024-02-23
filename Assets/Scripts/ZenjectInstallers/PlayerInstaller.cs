using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Player>().FromNew().AsCached().NonLazy();
    }
}