using UnityEngine;
using Assets.Scripts.Characters;

public class PeaEnemy : MonoBehaviour
{
    [SerializeField]
    private Vector3 movementValue;

    [SerializeField]
    private MovementComponent movementComponent = new MovementComponent();
    [SerializeField]
    private AttackComponent attackComponent = new AttackComponent();

    void Update()
    {
        movementComponent.MoveTowards(transform, attackComponent.Target);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player is IHealth)
            {
                HitInfo hitInfo = new HitInfo(attackComponent.Damage, transform.position);
                (player as IHealth).Hit(hitInfo);
            }
        }
    }
}
