using Infrastructure.States;
using Zenject;
using BattleArena.Infrastructure.Services;
using BattleArena.Infrastructure.Services.SaveLoad;
using BattleArena.Infrastructure.Services.PersistentData;
using BattleArena.Infrastructure.Services.StaticData;
using BattleArena.Infrastructure.InputService;
using BattleArena.Infrastructure.Services.GameFactory;
using BattleArena.Infrastructure.Services.Assets;

namespace Infrastructure.Installers
{
    public class ServiceInstiller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStaticDataService();
            BindPersistentProgressService();
            BindSaveLoadService();
            BindSceneLoader();
            BindAssets();
            BindInputService();
            BindGameFactory();
            BindGameStateMachine();
        }

        private void BindStaticDataService() => 
            Container.Bind<IStaticDataService>().
            To<StaticDataService>().AsSingle();

        private void BindSaveLoadService() => 
            Container.Bind<ISaveLoadService>().
            To<SaveLoadService>().AsSingle();

        private void BindPersistentProgressService() => 
            Container.Bind<IPersistentProgressService>().
            To<PersistentProgressService>().AsSingle();

        private void BindGameStateMachine() =>
            Container.Bind<IGameStateMachine>().
            To<GameStateMachine>().AsSingle();

        private void BindSceneLoader() => 
            Container.Bind<SceneLoader>().AsSingle();

        private void BindAssets() =>
            Container.Bind<IAssets>().
            To<AssetProvider>().AsSingle();

        private void BindInputService() =>
            Container.Bind<IInputService>().
            To<InputService>().AsSingle();

        private void BindGameFactory() =>
            Container.Bind<IGameFactory>().
            To<GameFactory>().AsSingle();
    }
}