namespace AlgoTraining.Topics.S09T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static T Reservoir<T>(IEnumerable<T> values, Random random)
    {
        using var iterator = values.GetEnumerator();
        if (!iterator.MoveNext())
            throw new ArgumentException("Пустой поток.");
        var selected = iterator.Current;
        long count = 1;
        while (iterator.MoveNext())
        {
            count = checked(count + 1);
            if (random.NextInt64(count) == 0)
                selected = iterator.Current;
        }
        return selected;
    }
    public static void Shuffle<T>(Span<T> values, Random random) => random.Shuffle(values);
}
