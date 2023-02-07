using UnityEngine;
using BattleArena.Infrastructure.Services.SaveLoad;
using BattleArena.Infrastructure.Services.PersistentData;
using BattleArena.Infrastructure.Services.GameFactory;
using BattleArena.Enemy.Data;

namespace BattleArena.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour, ISavedProgress
    {
        public string Id { get; private set; } = string.Empty;

        private MonsterTypeId _monsterTypeId = default;

        private IGameFactory _factory = null;

        public void Constructor(string id, MonsterTypeId monsterTypeId, IGameFactory gameFactory)
        {
            Id = id;
            _monsterTypeId = monsterTypeId;
            _factory = gameFactory;
        }

        public void LoadProgress(IPersistentProgressService progressData)
        {
            
        }

        public void UpdateProgress(IPersistentProgressService progressData)
        {
            
        }

        private void Start() => Spawn();

        private async void Spawn()
        {
            GameObject enemy = await _factory.CreateEnemyAsync(_monsterTypeId, transform);
        }
    }
}
