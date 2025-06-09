using Assets.Scripts.Characters;
using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    private MovementComponent movementComponent;
    [SerializeField]
    private AttackComponent attackComponent;
    public AttackComponent AttackComponent { get { return attackComponent; } }
    [SerializeField]
    private SpriteComponent spriteComponent;
    [SerializeField]
    private HealthComponent healthComponent;
    public HealthComponent HealthComponent { get {return healthComponent;} }

    public static event Action<EnemyBase> OnSpawn;
    public static event Action<EnemyBase> OnDespawn;

    private void Start()
    {
        OnSpawn?.Invoke(this);
    }

    private void Update()
    {
        movementComponent?.UpdateMovement(this);
        attackComponent?.UpdateComponent();
        spriteComponent?.UpdateSprite(movementComponent.Velocity);
    }

    private void OnDestroy()
    {
        OnDespawn?.Invoke(this);
    }
}
