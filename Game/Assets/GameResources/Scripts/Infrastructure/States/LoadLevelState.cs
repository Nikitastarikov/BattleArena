using BattleArena.Infrastructure.Services;
using BattleArena.StaticData;
using UnityEngine.SceneManagement;
using UnityEngine;
using BattleArena.Infrastructure.Services.StaticData;
using BattleArena.Infrastructure.Services.GameFactory;
using System.Threading.Tasks;
using BattleArena.Enemy.StaticData;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader,
            IStaticDataService staticDataService, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _gameFactory = gameFactory;
        }

        public void Enter(string payload) => 
            _sceneLoader.LoadSceneAsync(payload, OnLoaded);

        public void Exit() { }

        private async void OnLoaded()
        {
            await InitGameWorld();

            _gameStateMachine.Enter<GameLoopState>();
        }

        public async Task InitGameWorld()
        {
            LevelStaticData levelData = GetLevelStaticData();

            await InitEnemySpawnersAsync(levelData);
            //InitLoot();
            GameObject hero = await InitHero(levelData);
            InitHud(hero);
        }

        private void InitHud(GameObject hero)
        {
        }

        private async Task<GameObject> InitHero(LevelStaticData levelData) =>
            await _gameFactory.CreateHeroAsync(levelData.InitialHeroPosition);

        private void InitLoot()
        {
        }

        private async Task InitEnemySpawnersAsync(LevelStaticData levelData)
        {
            foreach (EnemySpawnerData spawnerData in levelData.EnemySpawners)
            {
                await _gameFactory.CreateEnemySpawner(spawnerData.Position, spawnerData.Id, spawnerData.MonsterTypeId);
            }
        }

        private LevelStaticData GetLevelStaticData() =>
            _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
    }
}

