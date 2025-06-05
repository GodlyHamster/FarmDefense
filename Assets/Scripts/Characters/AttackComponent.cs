using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class AttackComponent
    {
        [SerializeField]
        private Transform target;
        public Transform Target { get { return target; } }

        [SerializeField]
        private int damage;
        public int Damage { get { return damage; } }

        public void Attack(IHealth target, HitInfo hit)
        {
            target.Hit(hit);
        }
    }
}