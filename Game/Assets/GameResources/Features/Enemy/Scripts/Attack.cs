using BattleArena.Logic;
using System.Linq;
using UnityEngine;

namespace BattleArena.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : MonoBehaviour
    {
        public float AttackCooldown = 3f;
        public float Cleavage = 0.5f;
        public float EffectiveDistance = 0.5f;
        public float Damage = 10f;

        private const string LAYER_PLAYER_NAME = "Player";

        private float _currentAttackCooldown;

        private int _layerMask;

        private bool _isAttacking;
        private bool _attackIsActive;

        [SerializeField]
        private EnemyAnimator _animator = default;
        private Collider[] _hits = new Collider[1];
        private Transform _heroTransform = default;

        public void Constructor(Transform heroTransform) => 
            _heroTransform = heroTransform;

        public void DisableAttack() => 
            _attackIsActive = false;

        public void EnableAttack() => 
            _attackIsActive = true;

        private void Awake() => 
            _layerMask = 1 << LayerMask.NameToLayer(LAYER_PLAYER_NAME);

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
                StartAttack();
        }

        private void OnAttackEnded()
        {
            _currentAttackCooldown = AttackCooldown;
            _isAttacking = false;
        }

        private void OnAttack()
        {
            if (Hit(out Collider hit))
            {
                PhysicsDebug.DrawDebug(StartPoint(), Cleavage, 1f);
                hit.transform.GetComponent<IHealth>().TakeDamage(Damage);
            }
        }

        private bool CanAttack() =>
            _attackIsActive && !_isAttacking && CooldownIsUp();

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _currentAttackCooldown -= Time.deltaTime;
        }

        private void StartAttack()
        {
            transform.LookAt(_heroTransform);
            _animator.PlayAttack();

            _isAttacking = true;
        }

        private bool Hit(out Collider hit)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(StartPoint(), Cleavage, _hits, _layerMask);

            hit = _hits.FirstOrDefault();

            return hitCount > 0;
        }

        private Vector3 StartPoint() =>
            new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
            transform.forward * EffectiveDistance;

        private bool CooldownIsUp() => _currentAttackCooldown <= 0f;
    }
}
