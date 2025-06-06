using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField]
        private int maxHealth;
        [SerializeField]
        private int health;

        public event Action OnHealthChanged;

        private void Awake()
        {
            if (health == 0) health = maxHealth;
        }

        private void AddHealth(int healthAmount)
        {
            health += healthAmount;
            if (health > maxHealth) health = maxHealth;
            OnHealthChanged?.Invoke();
        }

        private void RemoveHealth(int healthAmount)
        {
            health -= healthAmount;
            OnHealthChanged?.Invoke();
            if (health <= 0) Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void Hit(HitInfo hitInfo)
        {
            RemoveHealth(hitInfo.damage);
        }
    }
}