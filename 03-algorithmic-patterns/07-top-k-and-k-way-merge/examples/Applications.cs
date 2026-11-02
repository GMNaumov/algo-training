namespace AlgoTraining.Topics.S03T07;

[Lesson("03-algorithmic-patterns/07-top-k-and-k-way-merge", "Top K и слияние K последовательностей")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 60, 70, 90 }, Canonical.Largest([40, 10, 70, 30, 90, 60], 3), "Три крупных заказа");
        Check.Sequence(new[] { 8, 8 }, Modern.Largest([8, 1, 8, 4], 2), "Повторы в рейтинге");
        int[][] logs = [new[] { 1, 7 }, new[] { 2, 5 }, new[] { 3, 4 }];
        Check.Sequence(new[] { 1, 2, 3, 4, 5, 7 }, Canonical.Merge(logs), "Слияние журналов эталоном");
        Check.Sequence(Canonical.Merge(logs), Modern.Merge(logs), "Слияние очередью приоритетов");
    }
}
