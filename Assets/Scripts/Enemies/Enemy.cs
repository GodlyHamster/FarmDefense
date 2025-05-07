using UnityEngine;

public abstract class Enemy : MonoBehaviour, IHealth
{
    public float health { get; private set; } = 1f;
    [field: SerializeField]
    public float maxHealth { get; private set; } = 1f;

    private void Start()
    {
        health = maxHealth;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
        }
    }
}
