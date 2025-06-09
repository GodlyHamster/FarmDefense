using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField]
        private int maxHealth;
        public int MaxHealth { get { return maxHealth; } }
        [SerializeField]
        private int health;
        public int Health { get { return health; } }

        [SerializeField]
        private bool destroyOnDeath = true;

        public event Action<int, int> OnHealthChanged;

        public UnityEvent OnDeath = new UnityEvent();

        private void Awake()
        {
            if (health == 0) health = maxHealth;
        }

        private void AddHealth(int healthAmount)
        {
            health += healthAmount;
            if (health > maxHealth) health = maxHealth;
            OnHealthChanged?.Invoke(health, maxHealth);
        }

        private void RemoveHealth(int healthAmount)
        {
            health -= healthAmount;
            OnHealthChanged?.Invoke(health,maxHealth);
            if (health <= 0) Die();
        }

        private void Die()
        {
            OnDeath.Invoke();
            if (destroyOnDeath) Destroy(gameObject);
        }

        public void Hit(HitInfo hitInfo)
        {
            RemoveHealth(hitInfo.damage);
        }
    }
}