namespace AlgoTraining.Topics.S01T04;

[Lesson("01-foundations/04-csharp-for-algorithms", "C# для алгоритмических задач")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(3_000_000_000L, Canonical.Sum([1_500_000_000, 1_500_000_000]), "Большая выручка");
        Check.Equal(4, Canonical.Remainder(-1, 5), "Циклический индекс");
        Check.Equal(1, Modern.CodePoints("😀"), "Кодовая точка emoji");
        Check.Equal(6L, Modern.Sum([1, 2, 3]), "Сумма через LINQ");
    }
}
