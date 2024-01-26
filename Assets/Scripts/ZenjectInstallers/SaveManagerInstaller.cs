using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class SaveManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SaveManager>().FromNew().AsCached().NonLazy();
    }
}