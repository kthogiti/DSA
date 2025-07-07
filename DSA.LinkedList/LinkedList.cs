namespace DSA.LinkedList;

public class LinkedList<T> where T : notnull
{
    public Node<T>? Head { get; set; }
    public int Length;

    public LinkedList()
    {
        Head = null;
        Length = 0;
    }

    public void InsertAtHead(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
        Length++;
    }

    public void InsertAtTail(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node<T>? current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        Length++;
    }

    public void InsertAtPosition(T data, int position)
    {
        if (position < 0 || position > Length)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        if (position == 0)
        {
            InsertAtHead(data);
            return;
        }
        if (position == Length)
        {
            InsertAtTail(data);
            return;
        }

        Node<T> newNode = new Node<T>(data);
        Node<T>? current = Head;
        for (int i = 0; i < position - 1; i++)
        {
            current = current?.Next;
        }

        if (current != null)
        {
            newNode.Next = current.Next;
            current.Next = newNode;
            Length++;
        }
    }

    public void DeleteAtHead()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        Head = Head.Next;
        Length--;
    }

    public void DeleteAtTail()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        if (Head.Next == null)
        {
            Head = null;
            return;
        }
        Node<T>? current = Head;
        while (current.Next?.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
        Length--;
    }

    public void DeleteAtPosition(int position)
    {
        if (position < 0 || Head == null)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        if (position >= Length)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        if (position == 0)
        {
            DeleteAtHead();
            return;
        }
        if (position == Length - 1)
        {
            DeleteAtTail();
            return;
        }

        Node<T>? current = Head;
        for (int i = 1; i < position; i++)
        {
            current = current?.Next;
        }

        if (current != null && current.Next != null)
        {
            current.Next = current.Next.Next;
            Length--;
        }
    }

    public Array ToArray()
    {
        T[] array = new T[Length];
        Node<T>? current = Head;
        int index = 0;
        while (current != null)
        {
            array[index++] = current.Data;
            current = current.Next;
        }
        return array;
    }

    public bool Contains(T data)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Clear()
    {
        Head = null;
        Length = 0;
    }

    public override string ToString()
    {
        if (Head == null)
        {
            return "[]";
        }

        Node<T>? current = Head;
        var result = new System.Text.StringBuilder("[");
        while (current != null)
        {
            result.Append(current.Data);
            if (current.Next != null)
            {
                result.Append(", ");
            }
            current = current.Next;
        }
        result.Append("]");
        return result.ToString();
    }
    
    public LinkedList<T> Reverse()
    {
        LinkedList<T> reversedList = new();
        Node<T>? current = Head;
        while (current != null)
        {
            reversedList.InsertAtHead(current.Data);
            current = current.Next;
        }
        return reversedList;
    }
}
