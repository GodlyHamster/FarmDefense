using Assets.Scripts.Characters;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    protected MovementComponent movementComponent = new MovementComponent();
    [SerializeField]
    protected AttackComponent attackComponent = new AttackComponent();
    [SerializeField]
    protected SpriteComponent spriteComponent = new SpriteComponent();

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
