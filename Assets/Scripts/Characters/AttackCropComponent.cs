using UnityEngine;
using Assets.Scripts.Characters;

public class AttackCropComponent : AttackComponent
{
    private void Start()
    {
        CropManager.OnFarmUpdated += UpdateAttackTarget;
    }

    private void UpdateAttackTarget()
    {
        foreach (var item in CropManager.instance.PlantedCrops)
        {
            Debug.Log($"{item.Value.cropType.name} is at {item.Key}");
        }
    }
}
