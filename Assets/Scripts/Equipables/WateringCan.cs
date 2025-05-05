using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "WateringCan", menuName = "ScriptableObjects/Tools/Watering Can", order = 1)]
public class WateringCan : EquipableItem
{
    [Tooltip("Indicates for how many seconds a crop is watered")]
    public float wateringValue = 1f;

    public override void Equip()
    {
        base.Equip();
    }

    public override void Dequip()
    {
        base.Dequip();
    }

    public override void Use(Vector2Int useLocation, GameObject user)
    {
        base.Use(useLocation, user);
        CropManager.instance.WaterCrop(useLocation, wateringValue);
    }
}
