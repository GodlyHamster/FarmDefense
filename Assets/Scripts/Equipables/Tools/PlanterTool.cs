using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Planter", menuName = "ScriptableObjects/Tools/Planter", order = 0)]
public class PlanterTool : EquipableItem, SubtoolInterface
{
    [field: SerializeField]
    public List<CropScriptableObject> subtoolItems { get; private set; }
    public LinkedList<CropScriptableObject> subtoolLinkedList { get; private set; }
    public LinkedListNode<CropScriptableObject> subtoolNode { get; private set; }

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
        if (subtoolItems.Count == 0) return;
        CropManager.instance?.PlantCrop(useLocation, subtoolItems[0]);
    }

    public void NextSubtool()
    {
        if (subtoolNode == null) return;
        subtoolNode = subtoolNode.NextOrFirst();
    }

    public void PreviousSubtool()
    {
        if (subtoolNode == null) return;
        subtoolNode = subtoolNode.PreviousOrLast();
    }
}
