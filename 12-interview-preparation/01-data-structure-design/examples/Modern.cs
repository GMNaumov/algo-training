namespace AlgoTraining.Topics.S12T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern
{
    private readonly int capacity;
    private readonly LinkedList<(int Key, int Value)> recency = new();
    private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> index = [];
    public Modern(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);
        this.capacity = capacity;
    }
    public bool TryGet(int key, out int value)
    {
        if (!index.TryGetValue(key, out var node))
        {
            value = 0;
            return false;
        }
        recency.Remove(node);
        recency.AddFirst(node);
        value = node.Value.Value;
        return true;
    }
    public void Put(int key, int value)
    {
        if (capacity == 0)
            return;
        if (index.Remove(key, out var existing))
            recency.Remove(existing);
        index[key] = recency.AddFirst((key, value));
        if (index.Count <= capacity)
            return;
        var oldest = recency.Last!;
        index.Remove(oldest.Value.Key);
        recency.RemoveLast();
    } // Ожидаемо O(1), O(C). Словарь и список всегда содержат одни и те же ключи.
}
