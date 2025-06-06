using UnityEngine;

namespace Assets.Scripts.Characters.Enemies
{
    public class GroundMovement : MovementComponent
    {
        public override void UpdateMovement(EnemyBase enemybase)
        {
            MoveTowards(enemybase.AttackComponent.Target);
        }
    }
}