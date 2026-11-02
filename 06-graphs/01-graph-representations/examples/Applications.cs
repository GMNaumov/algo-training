namespace AlgoTraining.Topics.S06T01;

[Lesson("06-graphs/01-graph-representations", "Представление графов")]
public static class Applications
{
    public static void Run()
    {
        bool[,] roads = new bool[3, 3];
        roads[0, 1] = true;
        roads[1, 2] = true;
        Check.Sequence(new[] { 1 }, Canonical.FromMatrix(roads)[0], "Дороги из первого склада");
        int[][] links = Modern.FromEdges(4, [(0, 1), (1, 2), (0, 2)]);
        Check.Sequence(new[] { 1, 2 }, links[0], "Исходящие ссылки страницы");
        Check.Equal(0, links[3].Length, "Изолированная вершина сохранена");
    }
}
