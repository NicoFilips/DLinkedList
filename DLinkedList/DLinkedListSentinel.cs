namespace DLinkedList;

internal sealed record DLinkedListSentinel<T>
{
    public DLinkedListNode<T>? First { get; set; }
    public DLinkedListNode<T>? Last { get; set; }
}
