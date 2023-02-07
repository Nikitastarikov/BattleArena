using UnityEngine;
using BattleArena.Enemy.Data;

namespace BattleArena.Enemy
{
    public class EnemySpawnMarker : MonoBehaviour
    {
        public MonsterTypeId MonsterTypeId => _monsterTypeId;

        [SerializeField]
        private MonsterTypeId _monsterTypeId = default;
    }
}
