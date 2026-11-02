namespace AlgoTraining.Topics.S10T02;

[Lesson("10-string-algorithms/02-knuth-morris-pratt", "Алгоритм Кнута — Морриса — Пратта")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 2 }, Canonical.Find("abababac", "ababac"), "Поиск повторного кода");
        Check.Sequence(new[] { 0, 1 }, Modern.Find("aaaa", "aaa"), "Поток позиций сигнала");
        Check.Sequence(new[] { 0, 0, 1, 2, 3 }, Canonical.Prefix("ababa"), "Границы образца");
    }
}
