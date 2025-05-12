using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Planter", menuName = "ScriptableObjects/Items/Tools/Planter", order = 0)]
public class PlanterTool : EquipableItem, SubtoolInterface
{
    [field: SerializeField]
    public List<Item> subtoolItems { get; private set; }
    public LinkedList<Item> subtoolLinkedList { get; private set; }
    public LinkedListNode<Item> subtoolNode { get; private set; }

    private void Awake()
    {
        foreach (Item item in subtoolItems)
        {
            subtoolLinkedList.AddLast(item);
        }
        subtoolNode = subtoolLinkedList.First;
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
