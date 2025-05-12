using System.Collections.Generic;

public class EquipableSubtoolItem<T> : EquipableItem
{
    public List<T> subtoolList = new List<T>();
    public LinkedList<T> subtoolLinkedList = new LinkedList<T>();
    public LinkedListNode<T> subtoolNode;

    public override void SubtoolNext()
    {
        if (subtoolNode == null) return;
        subtoolNode = subtoolNode.NextOrFirst();
    }

    public override void SubtoolPrevious()
    {
        if (subtoolNode == null) return;
        subtoolNode = subtoolNode.PreviousOrLast();
    }
}
