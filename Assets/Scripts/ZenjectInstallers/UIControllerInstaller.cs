using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class UIControllerInstaller : MonoInstaller
{
    [SerializeField] private UIService _uiService;
    
    public override void InstallBindings()
    {
        Container.Bind<UIService>().FromInstance(_uiService).AsSingle().NonLazy();
        Container.Bind<NavigationController>().FromNew().AsSingle().NonLazy();
        Container.QueueForInject(_uiService);
    }
}