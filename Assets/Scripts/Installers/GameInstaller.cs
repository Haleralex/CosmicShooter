using Navigation;
using SkinSystem;
using UISystem;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Skins skins;
    [SerializeField] private StartupConfig startupConfig;
    public override void InstallBindings()
    {
        Container.Bind<SkinViewer>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<Skins>()
               .FromScriptableObject(skins)
               .AsSingle()
               .NonLazy();

        Container.Bind<IAddressableLoader>().To<AddressableLoader>().AsTransient();
        Container.Bind<IAddressableReleaser>().To<AddressableReleaser>().AsTransient();

        Container.Bind<IUIPanelSwitcher>().To<UIPanelSwitcher>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<SkinChangerModel>().AsSingle();
        Container.Bind<SkinChangerView>()
            .FromComponentInHierarchy()
            .AsSingle();
        Container.Bind<SkinChangerPresenter>().AsSingle().NonLazy();
    }

    public override void Start()
    {
        var skinChangerPresenter = Container.Resolve<SkinChangerPresenter>();

        skinChangerPresenter.SetCurrentSkin();
    }
}
