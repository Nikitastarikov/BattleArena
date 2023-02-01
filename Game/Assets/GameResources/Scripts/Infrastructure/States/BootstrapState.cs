using BattleArena.Infrastructure.Services;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private string START_SCENE_NAME = "MenuScene";
        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader) 
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(START_SCENE_NAME, onLoaded: EnterLoadLevel);
        }

        public void Exit() {}

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadProgressState>();
    }
}

