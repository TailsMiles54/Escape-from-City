using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsCached().NonLazy();
        Container.Bind<RaidManager>().AsCached().NonLazy();
        Container.BindInterfacesAndSelfTo<EquipmentReserveManager>().AsCached().NonLazy();
        Container.BindInterfacesAndSelfTo<ShelterManager>().AsCached().NonLazy();
    }
}