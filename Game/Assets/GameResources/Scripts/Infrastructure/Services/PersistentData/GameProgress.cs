using System;
using System.Numerics;

namespace BattleArena.Infrastructure.Services.PersistentData
{
    public class PositionOnLevel : IProgress
    {
        public string Level;
        public Vector3 Position;

        public PositionOnLevel() : this("", new Vector3(0f, 0f, 0f)) { }

        public PositionOnLevel(string level, Vector3 position)
        {
            Level = level;
            Position = position;
        }
    }

    [Serializable]
    public class HeroState : IProgress
    {
        public float CurrentHp;
        public float MaxHp;

        public void ResetHp() => CurrentHp = MaxHp;
    }

    public interface IProgress
    {
    }
}

