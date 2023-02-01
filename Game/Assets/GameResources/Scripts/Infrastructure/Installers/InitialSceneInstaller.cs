using Infrastructure.States;
using UnityEngine;
using Zenject;
using BattleArena.Infrastructure.Services;
using BattleArena.Infrastructure.Services.SaveLoad;
using BattleArena.Infrastructure.Services.PersistentData;

namespace Infrastructure.Installers
{
    public class InitialSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameBootstrapper _gameBootstrapper;

        public override void InstallBindings()
        {
            BindPersistentProgressService();
            BindSaveLoadService();
            BindSceneLoader(_gameBootstrapper);
            BindGameStateMachine();
        }

        private void BindSaveLoadService()
        {
            Container.Bind<ISaveLoadService>().
                        To<SaveLoadService>().
                        AsSingle();
        }

        private void BindPersistentProgressService()
        {
            Container.Bind<IPersistentProgressService>().
                        To<PersistentProgressService>().
                        AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().
                To<GameStateMachine>().
                AsSingle();
        }

        private void BindSceneLoader(ICoroutineRunner coroutineRunner)
        {
            Container.Bind<SceneLoader>().
                FromInstance(new SceneLoader(coroutineRunner)).
                AsSingle();
        }
    }
}