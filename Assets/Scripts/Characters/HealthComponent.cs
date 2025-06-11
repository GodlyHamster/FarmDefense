using Assets.Scripts.Utility;
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
        private Transform healthbar;

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
            UpdateHealth();
        }

        private void RemoveHealth(int healthAmount)
        {
            health -= healthAmount;
            UpdateHealth();
            if (health <= 0) Die();
        }

        private void UpdateHealth()
        {
            OnHealthChanged?.Invoke(health, maxHealth);
            if (healthbar == null) return;
            float xScale = Utility.Utility.Remap(health, 0, maxHealth, 0, 1);
            healthbar.localScale = new Vector3(xScale, 0.1f);
        }

        private void Die()
        {
            OnDeath?.Invoke();
            if (destroyOnDeath) Destroy(gameObject);
        }

        public void Hit(HitInfo hitInfo)
        {
            RemoveHealth(hitInfo.damage);
        }
    }
}