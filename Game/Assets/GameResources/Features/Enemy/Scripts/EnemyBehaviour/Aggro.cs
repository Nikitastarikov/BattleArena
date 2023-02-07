﻿using System.Collections;
using UnityEngine;

namespace BattleArena.Enemy
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField]
        private TriggerObserver _triggerObserver= default;

        [SerializeField]
        private Follow _follow = default;

        [SerializeField]
        private float _coolDown = 1f;

        private bool _hasAggroTarget = false;

        private Coroutine _aggroCoroutine = default;

        private void Start()
        {
            SubscriptionToTrigger();

            SwitchFollowOff();
        }

        private void OnDestroy() => UnsubscriptionToTrigger();

        private void SubscriptionToTrigger()
        {
            _triggerObserver.onTriggerEnter += TriggerEnter;
            _triggerObserver.onTriggerExit += TriggerExit;
        }

        private void UnsubscriptionToTrigger()
        {
            _triggerObserver.onTriggerEnter -= TriggerEnter;
            _triggerObserver.onTriggerExit -= TriggerExit;
        }

        private void TriggerExit(Collider obj)
        {
            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;

                _aggroCoroutine = StartCoroutine(SwitchFollowOffAfterCoolDown());
            }
        }

        private void TriggerEnter(Collider obj)
        {
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;

                StopAggroCoroutine();

                SwitchFollowOn();
            }
        }

        private IEnumerator SwitchFollowOffAfterCoolDown()
        {
            yield return new WaitForSeconds(_coolDown);
            SwitchFollowOff();
        }

        private void StopAggroCoroutine()
        {
            if (_aggroCoroutine != null)
            {
                StopCoroutine(_aggroCoroutine);
            }
        }

        private void SwitchFollowOn() => _follow.enabled = true;
        private void SwitchFollowOff() => _follow.enabled = false;
    }
}
