namespace AlgoTraining.Topics.S02T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern<T>
{
    // LinkedList позволяет реализовать дек стандартными операциями на концах за O(1).
    private readonly LinkedList<T> items = new();
    public void AddFirst(T value) => items.AddFirst(value);
    public void AddLast(T value) => items.AddLast(value);
    public T RemoveFirst()
    {
        if (items.First is not { } first)
            throw new InvalidOperationException("Дек пуст.");
        items.RemoveFirst();
        return first.Value;
    }
    public T RemoveLast()
    {
        if (items.Last is not { } last)
            throw new InvalidOperationException("Дек пуст.");
        items.RemoveLast();
        return last.Value;
    }
}
