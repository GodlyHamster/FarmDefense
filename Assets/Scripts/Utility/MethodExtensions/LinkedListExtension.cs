using System.Collections.Generic;

public static class LinkedListExtension
{
    public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> node)
    {
        if (node.Next == null) return node.List.First;
        return node.Next;
    }

    public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> node)
    {
        if (node.Previous == null) return node.List.Last;
        return node.Previous;
    }
}
