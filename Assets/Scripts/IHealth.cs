using UnityEngine;

public interface IHealth
{
    public float health { get; }
    public float maxHealth { get; }

    public virtual void AddHealth(int amount) { }
    public virtual void RemoveHealth(int amount) { }
    public virtual void Hit() { }
}
