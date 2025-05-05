using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Harvester", menuName = "ScriptableObjects/Tools/Harvester", order = 2)]
public class HarvestTool : EquipableItem
{
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
