using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Tools/Weapon", order = 3)]
public class Weapon : EquipableItem
{
    public CropScriptableObject ammoType;
    public float firingCooldown = 0.3f; //Not implemented yet

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
        if (Inventory.instance.RemoveAmount(ammoType, 1))
        {
            Debug.Log($"We pewpew da {ammoType.name}");
        }
    }
}
