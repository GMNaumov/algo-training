namespace AlgoTraining.Topics.S11T04;

[Lesson("11-advanced-topics/04-lowest-common-ancestor-and-binary-lifting", "Наименьший общий предок и двоичные подъёмы")]
public static class Applications
{
    public static void Run()
    {
        int[] parent = [0, 0, 0, 1, 1, 3];
        Check.Equal(1, new Canonical(parent).Lca(5, 4), "Общая папка");
        Modern organization = new(parent);
        Check.Equal(0, organization.Lca(5, 2), "Общий руководитель");
        Check.Equal(4, organization.Distance(5, 2), "Расстояние в иерархии");
        Check.Equal(3, organization.Lca(5, 3), "Один узел — предок другого");
    }
}
