using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace BattleArena.Infrastructure.Services
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IGameStateMachine _gameStateMachine = default;

        [Inject]
        private void Constructor(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _gameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
