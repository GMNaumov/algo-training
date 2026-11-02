namespace AlgoTraining.Topics.S06T02;

[Lesson("06-graphs/02-graph-traversals", "Обходы графов")]
public static class Applications
{
    public static void Run()
    {
        int[][] metro = [new[] { 1, 2 }, new[] { 0, 3 }, new[] { 0, 3 }, new[] { 1, 2, 4 }, new[] { 3 }, Array.Empty<int>()];
        Check.Sequence(new[] { 0, 1, 1, 2, 3, -1 }, Canonical.Distances(metro, 0), "Число переходов метро");
        Check.Sequence(new[] { 0, 1, 3, 2, 4 }, Canonical.DepthFirst(metro, 0), "Аудит достижимой сети");
        Check.Sequence(new[] { 0, 1, 3, 4 }, Modern.ShortestRoute(metro, 0, 4), "Восстановленный маршрут");
        Check.Equal(0, Modern.ShortestRoute(metro, 0, 5).Length, "Нет пути");
    }
}
