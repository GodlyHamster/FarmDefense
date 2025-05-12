using UnityEngine;
using System.Collections.Generic;

public interface SubtoolInterface
{
    [SerializeField]
    public List<CropScriptableObject> subtoolItems { get; }
    public LinkedList<CropScriptableObject> subtoolLinkedList { get; }
    public LinkedListNode<CropScriptableObject> subtoolNode { get; }

    public void NextSubtool();
    public void PreviousSubtool();
}
