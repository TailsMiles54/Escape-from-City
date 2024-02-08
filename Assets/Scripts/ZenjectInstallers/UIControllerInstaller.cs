using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class UIControllerInstaller : MonoInstaller
{
    [SerializeField] private UIService _uiService;
    [SerializeField] private PopupController _popupController;
    
    public override void InstallBindings()
    {
        Container.Bind<UIService>().FromInstance(_uiService).AsCached().NonLazy();
        Container.Bind<PopupController>().FromInstance(_popupController).AsCached().NonLazy();
        Container.QueueForInject(_uiService);
        Container.QueueForInject(_popupController);
        Container.BindInterfacesAndSelfTo<NavigationController>().AsCached().NonLazy();
    }
}