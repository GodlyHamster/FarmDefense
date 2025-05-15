using System;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    public float health { get; protected set; } = 1f;
    [field: SerializeField]
    public float maxHealth { get; private set; } = 1f;

    public static event Action<float, float> HealthUpdated;

    private void Start()
    {
        health = maxHealth;
    }

    public virtual void AddHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
        HealthUpdated?.Invoke(health, maxHealth);
    }

    public virtual void RemoveHealth(int amount)
    {
        health -= amount;
        HealthUpdated?.Invoke(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    [ContextMenu("Hit")]
    public virtual void Hit()
    {
        RemoveHealth(1);
    }

    public virtual void Die() 
    {
        Debug.Log("The player has died");
    }
}
