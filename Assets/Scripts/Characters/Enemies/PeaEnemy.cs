using UnityEngine;
using Assets.Scripts.Characters;

public class PeaEnemy : MonoBehaviour
{
    [SerializeField]
    private MovementComponent movementComponent = new MovementComponent();
    [SerializeField]
    private AttackComponent attackComponent = new AttackComponent();
    [SerializeField]
    private SpriteComponent spriteComponent = new SpriteComponent();

    private void Awake()
    {
        movementComponent.Initialize(GetComponent<Rigidbody2D>());
    }

    void Update()
    {
        movementComponent.MoveTowards(attackComponent.Target.position);
        spriteComponent.UpdateSprite(movementComponent.Velocity);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player is IHealth)
            {
                attackComponent.Attack(player as IHealth);
            }
        }
    }
}
