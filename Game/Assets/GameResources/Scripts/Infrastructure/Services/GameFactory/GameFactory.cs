using BattleArena.Enemy;
using BattleArena.Enemy.Data;
using BattleArena.Enemy.StaticData;
using BattleArena.Infrastructure.InputService;
using BattleArena.Infrastructure.Services.Assets;
using BattleArena.Infrastructure.Services.StaticData;
using Scripts.Hero;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BattleArena.Infrastructure.Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticDataService;

        [Inject]
        public GameFactory(IAssets assets, IInputService inputService, IStaticDataService staticDataService)
        {
            _assets = assets;
            _inputService = inputService;
            _staticDataService = staticDataService;
        }

        public async Task<GameObject> CreateEnemyAsync(MonsterTypeId typeId, Transform parent)
        {
            MonsterStaticData monsterData = _staticDataService.ForMonster(typeId);

            GameObject prefab = await _assets.LoadAsync<GameObject>(monsterData.PrefabReference);
            GameObject monster = Object.Instantiate(prefab, parent.position, Quaternion.identity, parent);

            return monster;
        }

        public async Task CreateEnemySpawner(Vector3 at, string spawnerId, MonsterTypeId monsterTypeId)
        {
            GameObject prefab = await _assets.LoadAsync<GameObject>(AssetAdresses.ENEMY_SPAWNER);
            EnemySpawnPoint spawner = Object.Instantiate(prefab, at, Quaternion.identity)
                .GetComponent<EnemySpawnPoint>();

            spawner.Constructor(spawnerId, monsterTypeId, this);
        }

        public async Task<GameObject> CreateHeroAsync(Vector3 at)
        {
            GameObject hero = await _assets.InstantiateAsync(AssetAdresses.HERO, at);
            hero.GetComponent<HeroMove>().Constructor(_inputService);
            hero.GetComponent<HeroLook>().Constructor(_inputService);
            
            return hero;
        }

        public Task<LootPiece> CreateLootAsync(Vector3 at)
        {
            return null;
        }
    }
}
