using BattleArena.Enemy.Data;
using System;
using UnityEngine;

namespace BattleArena.Enemy.StaticData
{
    [Serializable]
    public class EnemySpawnerData
    {
        public string Id = string.Empty;

        public MonsterTypeId MonsterTypeId = default;

        public Vector3 Position = default;

        public EnemySpawnerData(string id, MonsterTypeId monsterTypeId, Vector3 position)
        {
            Id = id;
            MonsterTypeId = monsterTypeId;
            Position = position;
        }
    }
}
