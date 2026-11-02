namespace AlgoTraining.Topics.S08T01;

[Lesson("08-greedy-algorithms/01-greedy-strategies", "Жадные стратегии")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(3, Canonical.Attend([new[] { 1, 4 }, new[] { 3, 5 }, new[] { 4, 6 }, new[] { 6, 8 }]), "Максимум встреч");
        Check.Equal(2, Modern.Attend([new(1, 2), new(2, 3), new(1, 3)]).Length, "Занятия без пересечений");
        Check.Equal(3, Canonical.GreedyCoins([1, 3, 4], 6), "Контрпример: жадно три монеты, оптимум две");
        Check.Equal(2, Canonical.GreedyCoins([1, 5, 10], 15), "Пример удачного размена");
    }
}
