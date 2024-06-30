namespace StackApp;

public class Stack1<T>
{
    private T[] array;
    private const int capacity = 10;
    private int size;

    public Stack1()
    {
        size = 0;
        array = new T[capacity];
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public int Count
    {
        get
        {
            return size;
        }
    }

    public T Pop()
    {
        if (size == 0)
        {
            throw new InvalidOperationException();
        }
        return array[size--];
    }

    public void Push(T newElement)
    {
        if (size == array.Length)
        {
            T[] newArray = new T[2 * array.Length];
            Array.Copy(array, newArray, size);
            array = newArray;
        }
        array[++size] = newElement;
    }
    public static bool CheckBrackets(string input)
    {
        Stack1<char> stack = new Stack1<char>();

        foreach (char c in input)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char openingBracket = stack.Pop();
                if ((c == ')' && openingBracket != '(') ||
                    (c == ']' && openingBracket != '[') ||
                    (c == '}' && openingBracket != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

}


public class Stack2<T>
{
    private List<T> _items = new List<T>();

    public void Push(T item)
    {
        _items.Add(item);
    }

    public T Pop()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _items[_items.Count - 1];
    }

    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public void Clear()
    {
        _items.Clear();
    }

    public void Extend(params T[] items)
    {
        foreach (T item in items)
        {
            _items.Add(item);
        }
    }

    public static bool CheckBrackets(string input)
    {
        Stack2<char> stack = new Stack2<char>();

        foreach (char c in input)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char openingBracket = stack.Pop();
                if ((c == ')' && openingBracket != '(') ||
                    (c == ']' && openingBracket != '[') ||
                    (c == '}' && openingBracket != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
