using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Planter", menuName = "ScriptableObjects/Tools/Planter", order = 0)]
public class PlanterTool : EquipableItem
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
        if (seedList.Count == 0) return;
        CropManager.instance?.PlantCrop(useLocation, seedList[0]);
    }
}
