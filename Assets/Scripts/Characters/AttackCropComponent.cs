using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class AttackCropComponent : AttackComponent
    {
        Vector2Int cropTarget;
        private Transform player;

        private bool targetPlayer = true;

        private void Start()
        {
            CropManager.OnFarmUpdated += UpdateAttackTarget;

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        public override void UpdateComponent()
        {
            if (targetPlayer)
            {
                target = player.position;
            }

            if (Vector2.Distance(transform.position, cropTarget) <= 0.3f)
            {
                CropManager.instance.DestroyCrop(cropTarget);
            }
        }

        private void UpdateAttackTarget()
        {
            var plantedCrops = CropManager.instance.PlantedCrops;
            if (plantedCrops.Count == 0)
            {
                targetPlayer = true;
                return;
            }
            targetPlayer = false;
            cropTarget = plantedCrops.GetRandomItem().Key;
            target = cropTarget;
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