using BattleArena.Infrastructure.InputService;
using BattleArena.Infrastructure.Services.PersistentData;
using BattleArena.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Scripts.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        public const float EPSILON = 0.01f;

        [SerializeField]
        private float _movementSpeed = 4.0f;
        [SerializeField]
        private float _jumpHeight = 1f;

        private bool _isGround = false;

        private Vector3 _movementVector = Vector3.zero;
        private Vector3 _jump = Vector3.zero;

        private CharacterController _characterController = default;
        private Camera _camera = default;
        private IInputService _inputService = default;

        public void UpdateProgress(IPersistentProgressService progressData)
        {
        }

        public void LoadProgress(IPersistentProgressService progressData)
        {
        }

        public void Constructor(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _camera = Camera.main;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_inputService == null)
                return;

            _movementVector = Vector3.zero;
            _isGround = _characterController.isGrounded;

            CheckAndResetIsGround();
            MoveXZ();
            MoveY();
        }

        private void CheckAndResetIsGround()
        {
            if (_isGround && _jump.y < 0f)
            {
                _jump.y = 0f;
            }
        }

        private void MoveXZ()
        {
            if (_inputService.Axis.sqrMagnitude > EPSILON)
            {
                _movementVector = new Vector3(_inputService.Axis.x, 0f, _inputService.Axis.y);
                _movementVector = transform.TransformDirection(_movementVector);
                _movementVector.Normalize();
            }
            _characterController.Move(_movementVector * _movementSpeed * Time.deltaTime);
        }

        private void MoveY()
        {
            Jump();

            _jump.y += EffectsOfGravity();
            _characterController.Move(_jump * Time.deltaTime);
        }

        private void Jump()
        {
            if (_inputService.IsJumpButtonPressed() && _isGround)
            {
                _jump.y += GetJumpForce();
            }
        }

        private float EffectsOfGravity() => 
            Physics.gravity.y * Time.deltaTime;

        private float GetJumpForce() =>
            Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
    }
}
