using Assets.Scripts.Characters;
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

    private void Update()
    {
        movementComponent?.UpdateMovement(this);
        attackComponent?.UpdateComponent();
        spriteComponent?.UpdateSprite(movementComponent.Velocity);
    }
}
