namespace AlgoTraining.Topics.S06T06;

[Lesson("06-graphs/06-shortest-paths", "Кратчайшие пути")]
public static class Applications
{
    public static void Run()
    {
        WeightedEdge[] delivery = [new(0, 1, 4), new(0, 2, 1), new(2, 1, 2), new(1, 3, 5)];
        Func<int, WeightedEdge[], int, long[]>[] methods = [Canonical.BellmanFord, Canonical.Dijkstra, Canonical.Dag, Modern.Dijkstra];
        foreach (var method in methods)
        {
            Check.Sequence(new long[] { 0, 3, 1, 8 }, method(4, delivery, 0), $"Доставка: {method.Method.Name}");
            Check.Sequence(new long[] { 0, 2, 5 }, method(3, [new(0, 1, 2), new(1, 2, 3)], 0), "Время этапов обработки");
        }
        Check.Equal(8L, Canonical.FloydWarshall(4, delivery)[0, 3], "Все пары складов");
        Check.Equal(5L, Canonical.FloydWarshall(3, [new(0, 1, 2), new(1, 2, 3)])[0, 2], "Все пары этапов");
        Check.Sequence(new long[] { 0, 0, 1 }, Modern.ZeroOneBfs(3, [new(0, 1, 0), new(1, 2, 1)], 0), "Бесплатные и платные переходы");
        Check.Sequence(new long[] { 0, 1, 0 }, Modern.ZeroOneBfs(3, [new(0, 1, 1), new(0, 2, 0)], 0), "Переключения режима");
        Check.Sequence(new[] { 0, 1, 2 }, S06T02.Canonical.Distances([new[] { 1 }, new[] { 2 }, Array.Empty<int>()], 0), "BFS при единичных весах");
        Check.Equal(-1L, Canonical.BellmanFord(2, [new(0, 1, -1)], 0)[1], "Отрицательное ребро");
        Check.Throws<ArgumentException>(() => Modern.Dijkstra(2, [new(0, 1, -1)], 0), "Запрет отрицательного веса в Дейкстре");
        Check.Throws<ArgumentException>(() => Canonical.BellmanFord(2, [new(0, 1, -1), new(1, 0, 0)], 0), "Отрицательный цикл");
    }
}
