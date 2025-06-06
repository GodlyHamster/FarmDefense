using UnityEngine;

public class AttackCropComponent
{
    public void Initialize()
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
