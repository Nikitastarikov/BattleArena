using System;

namespace BattleArena.Logic
{
    public interface IHealth
    {
        event Action onHealthChanged;
        
        float Max { get; set; }

        float Current { get; set; }

        void TakeDamage(float damage);
    }
}
