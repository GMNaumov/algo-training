namespace AlgoTraining.Topics.S11T07;

[Lesson("11-advanced-topics/07-network-flow", "Потоки в сетях")]
public static class Applications
{
    public static void Run()
    {
        int[,] network = new int[4, 4];
        network[0, 1] = 1;
        network[0, 2] = 1;
        network[1, 2] = 1;
        network[1, 3] = 1;
        network[2, 3] = 1;
        Check.Equal(2L, Canonical.Maximum(network, 0, 3), "Отмена неудачного пути через обратное ребро");
        Check.Equal(2L, Modern.Maximum(network, 0, 3).Flow, "Каналы передачи");
        int[,] assignment = new int[6, 6];
        assignment[0, 1] = assignment[0, 2] = assignment[1, 3] = assignment[1, 4] = assignment[2, 3] = assignment[3, 5] = assignment[4, 5] = 1;
        Check.Equal(2L, Canonical.Maximum(assignment, 0, 5), "Назначение исполнителей задачам");
        Check.Equal(2L, Modern.Maximum(assignment, 0, 5).Flow, "Назначение через BFS-пути");
    }
}
