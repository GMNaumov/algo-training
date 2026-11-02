namespace AlgoTraining.Topics.S12T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly List<KeyValuePair<int, int>> entries = new List<KeyValuePair<int, int>>();
    private readonly int capacity;
    public Canonical(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);
        this.capacity = capacity;
    }
    public bool TryGet(int key, out int value)
    {
        for (int i = 0; i < entries.Count; i++)
            if (entries[i].Key == key)
            {
                KeyValuePair<int, int> entry = entries[i];
                entries.RemoveAt(i);
                entries.Insert(0, entry);
                value = entry.Value;
                return true;
            }
        value = 0;
        return false;
    }
    public void Put(int key, int value)
    {
        for (int i = 0; i < entries.Count; i++)
            if (entries[i].Key == key)
            {
                entries.RemoveAt(i);
                break;
            }
        if (capacity == 0)
            return;
        entries.Insert(0, new KeyValuePair<int, int>(key, value));
        if (entries.Count > capacity)
            entries.RemoveAt(entries.Count - 1);
    } // Простой LRU: O(C) на операцию, память O(C).
}
public sealed class MinStack
{
    private readonly Stack<int> values = new Stack<int>();
    private readonly Stack<int> minima = new Stack<int>();
    public void Push(int value)
    {
        minima.Push(minima.Count == 0 ? value : Math.Min(value, minima.Peek()));
        values.Push(value);
    }
    public int Pop()
    {
        if (values.Count == 0)
            throw new InvalidOperationException("Стек пуст.");
        minima.Pop();
        return values.Pop();
    }
    public int Minimum
    {
        get
        {
            return minima.Peek();
        }
    }
    // Минимум O(1); Push амортизированно O(1), память O(n).
}
