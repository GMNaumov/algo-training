namespace AlgoTraining.Topics.S04T04;

[Lesson("04-recursion-sorting-searching/04-sorting-algorithms", "Алгоритмы сортировки")]
public static class Applications
{
    public static void Run()
    {
        Action<int[]>[] algorithms = [Canonical.Insertion, Canonical.Selection, Canonical.Merge, Canonical.Quick, Canonical.Heap, a => Canonical.Counting(a, 10)];
        foreach (var sort in algorithms)
        {
            int[] receipts = [7, 2, 5, 3];
            sort(receipts);
            Check.Sequence(new[] { 2, 3, 5, 7 }, receipts, $"Чеки: {sort.Method.Name}");
            int[] priorities = [2, 2, 1, 0];
            sort(priorities);
            Check.Sequence(new[] { 0, 1, 2, 2 }, priorities, "Приоритеты с повторами");
        }
        int[] modern = [-2, 5, 0];
        Modern.Sort(modern);
        Check.Sequence(new[] { -2, 0, 5 }, modern, "Span.Sort");
        Check.Sequence(new[] { "Борис", "Анна", "Вера" }, Modern.Stable([("Анна", 5), ("Борис", 3), ("Вера", 5)]).Select(x => x.Name), "Стабильность записей");
    }
}
