namespace AlgoTraining.Topics.S12T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed record Explanation(int Answer, string Invariant, string Time, string Space);
public static class Modern
{
    public static Explanation ExplainMaximum(ReadOnlySpan<int> values)
    {
        if (values.IsEmpty)
            throw new ArgumentException("Нужен непустой вход.");
        var best = values[0];
        foreach (var value in values)
            best = Math.Max(best, value);
        return new(best, "Храним максимум просмотренного префикса", "O(n)", "O(1)");
        // Здесь сохраняем только итоговый отчёт, а не n шагов.
    }
}
