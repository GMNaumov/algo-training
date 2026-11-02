namespace AlgoTraining.Topics.S11T06;

[Lesson("11-advanced-topics/06-eulerian-paths", "Эйлеровы пути и циклы")]
public static class Applications
{
    public static void Run()
    {
        int[] streets = Canonical.Undirected(4, new int[,] { { 0, 1 }, { 1, 2 }, { 2, 0 }, { 0, 3 } });
        Check.Equal(5, streets.Length, "Обход всех улиц");
        Check.Equal(3, Canonical.Undirected(2, new int[,] { { 0, 1 }, { 0, 1 } }).Length, "Два параллельных участка");
        Check.Sequence(new[] { 0, 1, 2, 0 }, Modern.Directed(3, [(0, 1), (1, 2), (2, 0)]), "Цикл переходов");
        Check.Sequence(new[] { 0, 1, 2 }, Modern.Directed(3, [(0, 1), (1, 2)]), "Сборка цепочки переходов");
    }
}
