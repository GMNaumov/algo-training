namespace AlgoTraining.Topics.S06T05;

[Lesson("06-graphs/05-union-find", "Система непересекающихся множеств")]
public static class Applications
{
    public static void Run()
    {
        Canonical offices = new Canonical(4);
        offices.Union(0, 1);
        offices.Union(2, 3);
        offices.Union(1, 2);
        Check.Equal(offices.Find(0), offices.Find(3), "Объединение офисов");
        Modern roads = new(5);
        roads.Union(0, 1);
        roads.Union(1, 2);
        roads.Union(3, 4);
        Check.Equal(false, roads.Union(0, 2), "Ребро замкнёт цикл");
        Check.Equal(2, roads.Components, "Две компоненты дорог");
    }
}
