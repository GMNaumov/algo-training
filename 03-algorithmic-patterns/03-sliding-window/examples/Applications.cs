namespace AlgoTraining.Topics.S03T03;

[Lesson("03-algorithmic-patterns/03-sliding-window", "Скользящее окно")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(9L, Canonical.MaxSum([2, 1, 5, 1, 3], 3), "Посетители за три дня");
        Check.Equal(-5L, Modern.MaxSum([-4, -2, -3], 2), "Убыточные периоды");
        Check.Equal(2, Canonical.LongestWithinBudget([2, 1, 3, 2], 4), "Занятия в бюджете времени");
        Check.Throws<ArgumentOutOfRangeException>(() => Modern.MaxSum([], 1), "Окно больше входа");
    }
}
