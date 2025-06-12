using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class AttackPlayerComponent : AttackComponent
    {
        private float attackCooldown = 2f;
        private float currentAttackCooldown = 2f;
        private bool canAttack = false;

        private bool collidingWithPlayer = false;

        private Transform player;
        private HealthComponent playerHealth;

        private void Start()
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            playerHealth = player.gameObject.GetComponent<HealthComponent>();
        }

        public override void UpdateComponent()
        {
            target = player.transform.position;

            if (currentAttackCooldown > 0)
            {
                currentAttackCooldown -= Time.deltaTime;
                if (currentAttackCooldown <= 0) canAttack = true;
            }

            if (canAttack && collidingWithPlayer)
            {
                playerHealth.Hit(new HitInfo(Damage));
                ActivateAttackCooldown();
            }
        }

        private void ActivateAttackCooldown()
        {
            canAttack = false;
            currentAttackCooldown = attackCooldown;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collidingWithPlayer = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collidingWithPlayer = false;
            }
        }
    }
}