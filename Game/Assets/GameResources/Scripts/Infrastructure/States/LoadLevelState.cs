using BattleArena.Infrastructure.Services;
using BattleArena.StaticData;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using BattleArena.Infrastructure.Services.StaticData;
using BattleArena.Infrastructure.Services.GameFactory;
using System.Threading.Tasks;
using UnityEditorInternal;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader, 
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoaded);
        }

        public void Exit()
        {
        }

        private async void OnLoaded()
        {
            await InitGameWorld();

            _gameStateMachine.Enter<GameLoopState>();
        }

        public async Task InitGameWorld()
        {
            LevelStaticData levelData = GetLevelStaticData();

            InitSpawners(levelData);
            InitLoot();
            GameObject hero = await InitHero(levelData);
            InitHud(hero);
        }

        private void InitHud(GameObject hero)
        {
            throw new NotImplementedException();
        }

        private async Task<GameObject> InitHero(LevelStaticData levelData) =>
            await _gameFactory.CreateHeroAsync(levelData.InitialHeroPosition);

        private void InitLoot()
        {
            throw new NotImplementedException();
        }

        private void InitSpawners(LevelStaticData levelData)
        {
            throw new NotImplementedException();
        }

        private LevelStaticData GetLevelStaticData() =>
            _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
    }
}

