using BattleArena.Enemy;
using BattleArena.Enemy.Data;
using System.Threading.Tasks;
using UnityEngine;

namespace BattleArena.Infrastructure.Services.GameFactory
{
    public interface IGameFactory
    {
        public Task<GameObject> CreateHeroAsync(Vector3 at);

        public Task<LootPiece> CreateLootAsync(Vector3 at);

        public Task<GameObject> CreateEnemyAsync(MonsterTypeId typeId, Transform parent);

        public Task CreateEnemySpawner(Vector3 at, string spawnerId, MonsterTypeId monsterTypeId);
    }
}
