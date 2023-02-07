﻿using System;
using UnityEngine;

namespace BattleArena.Enemy
{
    [RequireComponent(typeof(Attack))]
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField]
        private Attack _attack;

        [SerializeField]
        private TriggerObserver _triggerObserver;

        private void Start()
        {
            _triggerObserver.onTriggerEnter += TriggerEnter;
            _triggerObserver.onTriggerExit += TriggerExit;

            _attack.DisableAttack();
        }

        private void TriggerExit(Collider obj)
        {
            _attack.DisableAttack();
        }

        private void TriggerEnter(Collider obj)
        {
            _attack.EnableAttack();
        }
    }
}
