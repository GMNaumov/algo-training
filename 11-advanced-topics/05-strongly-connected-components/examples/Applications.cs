namespace AlgoTraining.Topics.S11T05;

[Lesson("11-advanced-topics/05-strongly-connected-components", "Компоненты сильной связности")]
public static class Applications
{
    public static void Run()
    {
        int[][] links = [new[] { 1 }, new[] { 0, 2 }, new[] { 3 }, new[] { 2 }];
        int[] first = Canonical.Kosaraju(links);
        int[] second = Modern.Tarjan(links);
        Check.Equal(true, first[0] == first[1] && first[1] != first[2], "Группы взаимных ссылок");
        Check.Equal(true, second[2] == second[3] && second[0] != second[3], "Те же группы Тарьяном");
        int[][] dependencies = [new[] { 1 }, new[] { 2 }, Array.Empty<int>()];
        Check.Equal(3, Canonical.Kosaraju(dependencies).Distinct().Count(), "Независимые компоненты этапов");
        Check.Equal(3, Modern.Tarjan(dependencies).Distinct().Count(), "Этапы: Тарьян");
    }
}
