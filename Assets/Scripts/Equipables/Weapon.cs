using System;
using UnityEngine;

[Serializable]
public class Weapon : EquipableItem
{
    public float useCooldown = 0.3f; //Not implemented yet

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
    }
}
