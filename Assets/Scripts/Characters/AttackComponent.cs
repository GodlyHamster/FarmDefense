using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class AttackComponent
    {
        [SerializeField]
        private Vector3 target;
        public Vector3 Target { get { return target; } }

        [SerializeField]
        private int damage;
        public int Damage { get { return damage; } }

        public void Attack(HitInfo hit)
        {
            throw new NotImplementedException();
        }
    }
}