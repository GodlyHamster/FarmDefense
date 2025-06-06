using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class AttackCropComponent : AttackComponent
    {

        private void Start()
        {
            CropManager.OnFarmUpdated += UpdateAttackTarget;
        }

        private void UpdateAttackTarget()
        {
            var plantedCrops = CropManager.instance.PlantedCrops;
            target = plantedCrops.GetRandomItem().Key;
        }
    }
}