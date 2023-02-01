using BattleArena.Infrastructure.InputService;
using UnityEngine;
using Zenject;

namespace Scripts.Hero
{
    public class HeroLook : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _limitVertical = new Vector2(-45.0f, 45.0f);

        [SerializeField]
        private float _sensitivity = 9f;
        private float _rotationX = 0f;

        private IInputService _inputService = default;

        public void Constructor(IInputService inputService) => 
            _inputService = inputService;

        private void Update()
        {
            if (_inputService == null)
                return;

            _rotationX -= _inputService.LookAxis.y * _sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, _limitVertical.x, _limitVertical.y);

            float delta = _inputService.LookAxis.x * _sensitivity;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
