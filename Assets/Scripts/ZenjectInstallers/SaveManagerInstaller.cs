using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class SaveManagerInstaller : MonoInstaller
{
    [SerializeField] private SaveManager _saveManager;
    
    public override void InstallBindings()
    {
        var saveManager = Container.InstantiatePrefabForComponent<SaveManager>(_saveManager, transform.position, quaternion.identity, null);

        Container.Bind<SaveManager>().FromInstance(saveManager).AsSingle().NonLazy();
        Container.QueueForInject(saveManager);
    }
}