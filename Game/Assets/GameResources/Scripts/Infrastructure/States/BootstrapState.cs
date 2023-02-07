using BattleArena.Infrastructure.Services;
using BattleArena.Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private string START_SCENE_NAME = "MenuScene";

        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader,
            IStaticDataService staticDataService) 
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;

            staticDataService.LoadMonsters();
        }

        public void Enter() => 
            _sceneLoader.LoadSceneAsync(START_SCENE_NAME, onLoaded: EnterLoadLevel);

        public void Exit() {}

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadProgressState>();
    }
}

