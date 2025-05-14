using UnityEngine;

public interface IHealth
{
    public float health { get; }
    public float maxHealth { get; }

    public virtual void AddHealth(int amount) { }

    public virtual void RemoveHealth(int amount) { }
    //add hit information that entities can react to
    public virtual void Hit() { }
    public virtual void Die() { }
}
