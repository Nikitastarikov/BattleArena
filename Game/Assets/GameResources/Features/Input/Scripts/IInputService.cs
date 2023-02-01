using UnityEngine;

namespace BattleArena.Infrastructure.InputService
{
    public interface IInputService
    {
        Vector2 LookAxis { get; }

        Vector2 Axis { get; }

        bool IsAttackButtonPressed();

        bool IsJumpButtonPressed();
    }
}
