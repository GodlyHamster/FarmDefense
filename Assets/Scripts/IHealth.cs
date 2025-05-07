using UnityEngine;

public interface IHealth
{
    public float health { get; }
    public float maxHealth { get; }

    public void AddHealth(int amount);
    public void RemoveHealth(int amount);
}
