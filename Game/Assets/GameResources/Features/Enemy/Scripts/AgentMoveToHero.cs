using UnityEngine;
using UnityEngine.AI;

namespace BattleArena.Enemy
{
    public class AgentMoveToHero : Follow
    {
        [SerializeField]
        private NavMeshAgent _agent;

        private Transform _heroTransform;

        public void Constructor(Transform heroTransform) => 
            _heroTransform = heroTransform;

        private void Update() => 
            SetDestinationForAgent();

        private void SetDestinationForAgent()
        {
            if (_heroTransform)
                _agent.destination = _heroTransform.position;
        }
    }
}
