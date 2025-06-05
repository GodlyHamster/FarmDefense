using UnityEngine;
using Assets.Scripts.Characters;

public class PeaEnemy : MonoBehaviour
{
    [SerializeField]
    private MovementComponent movementComponent = new MovementComponent();
    [SerializeField]
    private AttackComponent attackComponent = new AttackComponent();

    void Update()
    {
        movementComponent.MoveTowards(transform, attackComponent.Target.position);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player is IHealth)
            {
                attackComponent.Attack(player as IHealth, new HitInfo(1));
            }
        }
    }
}
