namespace DLinkedList;

public class DLinkedList<T>
{
    private readonly DLinkedListSentinel<T> _sentinel;

    public DLinkedList()
    {
        _sentinel = new DLinkedListSentinel<T>();
    }

    public DLinkedListNode<T> GetFirst() => _sentinel.First!;
    public DLinkedListNode<T> GetLast() => _sentinel.Last!;

    public void AppendEnd(T data)
    {
        var newNode = new DLinkedListNode<T>(data)
        {
            Prev = _sentinel.Last,
            Next = null
        };

        // Fuers erste hinzugefuegte Element
        _sentinel.Last ??= newNode;
        _sentinel.First ??= newNode;

        if (_sentinel.First != newNode)
        {
            DLinkedListNode<T> formerLast = _sentinel.Last!;
            _sentinel.Last = newNode;

            _sentinel.Last.Prev = formerLast;
            _sentinel.Last.Prev.Next = newNode;
        }
    }

    public void AppendStart(T data)
    {
        var newNode = new DLinkedListNode<T>(data)
        {
            Next = _sentinel.First,
            Prev = null
        };

        // Fuers erste hinzugefuegte Element
        _sentinel.First ??= newNode;
        _sentinel.Last ??= newNode;

        if (_sentinel.Last != newNode)
        {
            DLinkedListNode<T> formerLast = _sentinel.First!;
            _sentinel.First = newNode;

            _sentinel.First.Next = formerLast;
            _sentinel.First.Next.Prev = newNode;
        }
    }

    public void PrintForward()
    {
        DLinkedListNode<T>? current = _sentinel.First;
        while (current != null)
        {
            Console.Write(current!.Data + ", ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintBackward()
    {
        DLinkedListNode<T>? current = _sentinel.Last;
        while (current != null)
        {
            Console.Write(current!.Data + ", ");
            current = current.Prev;
        }
        Console.WriteLine();
    }

    public void Delete(T data)
    {
        DLinkedListNode<T>? current = _sentinel.First;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _sentinel.First = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _sentinel.Last = current.Prev;
                }
            }

            current = current.Next;
        }
    }
}
