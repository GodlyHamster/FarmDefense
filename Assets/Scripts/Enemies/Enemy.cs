using UnityEngine;

public abstract class Enemy : MonoBehaviour, IHealth
{
    public float health { get; protected set; } = 1f;
    [field: SerializeField]
    public float maxHealth { get; private set; } = 1f;

    [SerializeField]
    protected LootTable lootTable;

    private void Start()
    {
        health = maxHealth;
    }

    public virtual void AddHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

    public virtual void RemoveHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Hit(HitInfo hitInfo)
    {
        Debug.Log($"{gameObject.name} got hit");
    }
    public virtual void Die() 
    {
        Debug.Log($"{gameObject.name} is dead");
    }
}
