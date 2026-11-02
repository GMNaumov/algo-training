namespace AlgoTraining.Topics.S02T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly int[] buffer;
    private int head;
    public int Count
    {
        get; private set;
    }
    public Canonical(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));
        buffer = new int[capacity];
    }
    // Кольцевой буфер фиксированной ёмкости: обе операции O(1), память O(capacity).
    public void Enqueue(int value)
    {
        if (Count == buffer.Length)
            throw new InvalidOperationException("Очередь заполнена.");
        buffer[(head + Count) % buffer.Length] = value;
        Count++;
    }
    public int Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Очередь пуста.");
        int value = buffer[head];
        head = (head + 1) % buffer.Length;
        Count--;
        return value;
    }
}
