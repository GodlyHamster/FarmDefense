using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField]
        protected Vector2 target;
        public Vector2 Target { get { return target; } }

        [SerializeField]
        private int damage;
        public int Damage { get { return damage; } }

        public virtual void UpdateComponent()
        {
            Debug.Log("Updating attack");
        }

        public void Attack(IHealth target)
        {
            target.Hit(new HitInfo(damage));
        }
    }
}