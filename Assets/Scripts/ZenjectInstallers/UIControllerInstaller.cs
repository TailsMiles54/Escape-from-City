using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class UIControllerInstaller : MonoInstaller
{
    [SerializeField] private UIService _uiService;
    
    public override void InstallBindings()
    {
        // var uiService = Container
        //     .InstantiatePrefabForComponent<UIService>(_uiService, transform.position, quaternion.identity, null);

        Container.Bind<UIService>().FromInstance(_uiService).AsSingle().NonLazy();
        Container.QueueForInject(_uiService);
    }
}