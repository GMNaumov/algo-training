namespace AlgoTraining.Topics.S10T03;

[Lesson("10-string-algorithms/03-z-algorithm", "Z-алгоритм")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 0, 0, 3, 0, 1 }, Canonical.Z("ababa"), "Повторение начала строки");
        Check.Sequence(new[] { 0, 2 }, Modern.Find("ababa", "aba"), "Коды журнала");
        Check.Sequence(new[] { 0, 1, 2 }, Modern.Find("aaaa", "aa"), "Повторы сигнала");
    }
}
