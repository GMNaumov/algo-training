namespace AlgoTraining.Topics.S03T06;

[Lesson("03-algorithmic-patterns/06-monotonic-stacks-and-queues", "Монотонные стеки и очереди")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 2, 1, 0, 0 }, Canonical.Warmer([20, 18, 22, 21]), "Дни до потепления");
        Check.Sequence(new[] { 4, 4 }, Canonical.MaxWindows([3, 1, 4, 2], 3), "Пиковая нагрузка");
        Check.Sequence(new[] { 3, 3, 5 }, Modern.MaxWindows([1, 3, 2, 5], 2), "Максимум продаж");
        Check.Sequence(new[] { 2, 1, 0 }, Canonical.Warmer([5, 5, 6]), "Строгое повышение");
    }
}
