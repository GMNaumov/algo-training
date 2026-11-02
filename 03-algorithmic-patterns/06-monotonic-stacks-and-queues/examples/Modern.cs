namespace AlgoTraining.Topics.S03T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] MaxWindows(ReadOnlySpan<int> values, int size)
    {
        if (size <= 0 || size > values.Length)
            throw new ArgumentOutOfRangeException(nameof(size));
        LinkedList<int> deque = new();
        int[] result = new int[values.Length - size + 1];
        for (var i = 0; i < values.Length; i++)
        {
            if (deque.First is { } first && first.Value <= i - size)
                deque.RemoveFirst();
            while (deque.Last is { } last && values[last.Value] <= values[i])
                deque.RemoveLast();
            deque.AddLast(i);
            if (i >= size - 1)
                result[i - size + 1] = values[deque.First!.Value];
        }
        return result; // O(n), O(size) дополнительной памяти без результата.
    }
}
