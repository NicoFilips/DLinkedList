namespace DLinkedList;

public class DLinkedListNode<T>(T data)
{
    public T Data { get; set; } = data;
    public DLinkedListNode<T>? Next { get; set; }
    public DLinkedListNode<T>? Prev { get; set; }
}
