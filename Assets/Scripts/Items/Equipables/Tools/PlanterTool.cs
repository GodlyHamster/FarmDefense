using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Planter", menuName = "ScriptableObjects/Items/Tools/Planter", order = 0)]
public class PlanterTool : EquipableItem, SubtoolInterface
{
    [field: SerializeField]
    public List<Item> subtoolItems { get; private set; } = new List<Item>();
    public LinkedList<Item> subtoolLinkedList { get; private set; } = new LinkedList<Item>();
    public LinkedListNode<Item> subtoolNode { get; private set; }

    private void OnEnable()
    {
        subtoolLinkedList.Clear();
        foreach (Item item in subtoolItems)
        {
            subtoolLinkedList.AddLast(item);
        }
        subtoolNode = subtoolLinkedList.First;
    }

    private void OnDisable()
    {
        subtoolLinkedList.Clear();
        subtoolNode = null;
    }

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
        if (subtoolNode.Value is not CropScriptableObject) return;
        if (CropManager.instance.IsPlotOccupied(useLocation)) return;
        if (!Inventory.instance.RemoveAmount(subtoolNode.Value, 1)) return;
        CropManager.instance?.PlantCrop(useLocation, (subtoolNode.Value as CropScriptableObject));
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
