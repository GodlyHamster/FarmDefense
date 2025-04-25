using UnityEngine;
using System.Collections.Generic;

public class SeedsEquipable : EquipableItem
{
    [SerializeField]
    private List<CropScriptableObject> seedList = new List<CropScriptableObject>();

    public override void Equip()
    {
        throw new System.NotImplementedException();
    }

    public override void Dequip()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(Vector2Int useLocation, GameObject user)
    {
        throw new System.NotImplementedException();
    }
}
