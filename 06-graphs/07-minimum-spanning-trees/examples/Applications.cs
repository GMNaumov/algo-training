namespace AlgoTraining.Topics.S06T07;

[Lesson("06-graphs/07-minimum-spanning-trees", "Минимальные остовные деревья")]
public static class Applications
{
    public static void Run()
    {
        WeightedEdge[] offices = [new(0, 1, 1), new(1, 2, 2), new(0, 2, 4), new(2, 3, 3), new(1, 3, 5)];
        Check.Equal(6L, Canonical.Kruskal(4, offices), "Прокладка кабеля");
        Check.Equal(6L, Modern.Prim(4, offices), "Проверка Примом");
        WeightedEdge[] roads = [new(0, 1, 2), new(1, 2, 3), new(0, 2, 10)];
        Check.Equal(5L, Canonical.Kruskal(3, roads), "Общая цена дорог");
        Check.Equal(5L, Modern.Prim(3, roads), "Дороги: Прим");
        Check.Throws<ArgumentException>(() => Modern.Prim(2, []), "Несвязность");
    }
}
