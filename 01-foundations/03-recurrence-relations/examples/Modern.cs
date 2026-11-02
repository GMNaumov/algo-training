namespace AlgoTraining.Topics.S01T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Span-срез не копирует массив. Рекурсия по прежнему занимает O(log n) стека.
    public static long Sum(ReadOnlySpan<int> values) => values.Length switch
    {
        0 => 0,
        1 => values[0],
        _ => Sum(values[..(values.Length / 2)]) + Sum(values[(values.Length / 2)..])
    };
}
