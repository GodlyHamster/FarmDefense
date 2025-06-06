using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class AttackPlayerComponent : AttackComponent
    {
        [SerializeField]
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
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                if (player is IHealth)
                {
                    Attack(player);
                }
            }
        }
    }
}