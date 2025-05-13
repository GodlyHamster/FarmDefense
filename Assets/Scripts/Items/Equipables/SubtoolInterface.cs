using UnityEngine;
using System.Collections.Generic;

public interface SubtoolInterface
{
    [SerializeField]
    public List<Item> subtoolItems { get; }
    public LinkedList<Item> subtoolLinkedList { get; }
    public LinkedListNode<Item> subtoolNode { get; }

    public void NextSubtool();
    public void PreviousSubtool();
}
