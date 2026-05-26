//stack is LIFO data structure
public class Stack<T>
{
    private T[] _stack;
    private int _top;

    public Stack(int capacity)
    {
        _stack = new T[capacity];
        _top = -1;
    }

    public void Push(T item)
    {
        if (_top == _stack.Length - 1)
            Resize(_stack.Length * 2); // Double the capacity if stack is full

        _stack[++_top] = item;
    }

    public T Pop()
    {
        if (_top == -1)
            throw new InvalidOperationException("Stack is empty.");

        return _stack[_top--];
    }

    public T Peek()
    {
        if (_top == -1)
            throw new InvalidOperationException("Stack is empty.");

        return _stack[_top];
    }

    public bool IsEmpty()
    {
        return _top == -1;
    }

    public int Count()
    {
        return _top + 1;
    }

    public void Clear()
    {
        _top = -1;
    }

    public void Resize(int newCapacity)
    {
        if (newCapacity < Count())
            throw new InvalidOperationException("New capacity must be greater than current stack size.");

        T[] newStack = new T[newCapacity];
        Array.Copy(_stack, newStack, Count());
        _stack = newStack;
    }
}