using UnityEngine;
using Assets.Scripts.Characters;

public class PeaMovement : MovementComponent
{

    public override void UpdateMovement(EnemyBase enemybase)
    {
        MoveTowards(enemybase.AttackComponent.Target);
    }
}
