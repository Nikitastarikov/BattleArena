using UnityEngine;

namespace BattleArena.Infrastructure.InputService
{
    public class InputService : IInputService
    {
        public Vector2 Axis => _heroInput.Player.Move.ReadValue<Vector2>();

        public Vector2 LookAxis => _heroInput.Player.Look.ReadValue<Vector2>();

        private HeroInput _heroInput = default;
        public InputService()
        {
            _heroInput = new HeroInput();

            _heroInput.Enable();
        }

        public bool IsAttackButtonPressed()
        {
            throw new System.NotImplementedException();
        }

        public bool IsJumpButtonPressed() =>
            _heroInput.Player.Jump.IsPressed();
    }
}
