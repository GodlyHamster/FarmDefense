using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class AttackPlayerComponent : AttackComponent
    {
        private Transform player;

        private void Start()
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        public override void UpdateComponent()
        {
            target = player.transform.position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent healthComponent))
                {
                    healthComponent.Hit(new HitInfo(Damage));
                }
            }
        }
    }
}