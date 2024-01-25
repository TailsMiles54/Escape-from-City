using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class UIControllerInstaller : MonoInstaller
{
    [SerializeField] private UIService _uiService;
    
    public override void InstallBindings()
    {
        Container.Bind<UIService>().FromInstance(_uiService).AsCached().NonLazy();
        Container.Bind<NavigationController>().FromNew().AsCached().NonLazy();
        Container.QueueForInject(_uiService);
    }
}