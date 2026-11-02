namespace AlgoTraining.Topics.S04T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Библиотечная сортировка на месте; Span не требует копии. Нестабильна.
    public static void Sort(Span<int> values) => values.Sort();
    public static (string Name, int Priority)[] Stable(IEnumerable<(string Name, int Priority)> values) =>
        values.OrderBy(value => value.Priority).ToArray(); // LINQ OrderBy стабилен, O(n) памяти.
}
