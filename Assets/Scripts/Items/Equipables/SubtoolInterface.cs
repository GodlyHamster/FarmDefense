using UnityEngine;
using System.Collections.Generic;

//TODO FIX: Make subtoolinterface generic where the type is typeof Item
//this is to make tools choose what type of subtools they accept (E.G. Cropscriptable, Ammo)

//also perhaps make this class a subclass of EquipableItem again so that we can implement base functionality for adding items to the subtoolLinkedList
public interface SubtoolInterface
{
    [SerializeField]
    public List<Item> subtoolItems { get; }
    public LinkedList<Item> subtoolLinkedList { get; }
    public LinkedListNode<Item> subtoolNode { get; }

    public void NextSubtool();
    public void PreviousSubtool();
}
