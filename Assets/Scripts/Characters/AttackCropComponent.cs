using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class AttackCropComponent : AttackComponent
    {
        Vector2Int cropTarget;

        private void Start()
        {
            CropManager.OnFarmUpdated += UpdateAttackTarget;
        }

        public override void UpdateComponent()
        {
            if (Vector2.Distance(transform.position, cropTarget) <= 0.3f)
            {
                CropManager.instance.DestroyCrop(cropTarget);
            }
        }

        private void UpdateAttackTarget()
        {
            var plantedCrops = CropManager.instance.PlantedCrops;
            cropTarget = plantedCrops.GetRandomItem().Key;
            target = cropTarget;
        }
    }
}