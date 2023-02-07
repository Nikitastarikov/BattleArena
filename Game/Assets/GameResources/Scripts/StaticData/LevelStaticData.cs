using BattleArena.Enemy.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;

        public List<EnemySpawnerData> EnemySpawners;

        public Vector3 InitialHeroPosition;
    }
}
