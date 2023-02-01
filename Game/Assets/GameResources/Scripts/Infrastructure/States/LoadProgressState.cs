using BattleArena.Infrastructure.Services.PersistentData;
using BattleArena.Infrastructure.Services.SaveLoad;

namespace Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(IGameStateMachine gameStateMachine, IPersistentProgressService persistentProgressService,
            ISaveLoadService _saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentProgressService = persistentProgressService;
        }

        public void Enter() => 
            LoadProgressOrInitNew();

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            
        }
    }
}

