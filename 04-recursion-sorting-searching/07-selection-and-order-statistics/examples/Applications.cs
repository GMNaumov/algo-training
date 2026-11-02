namespace AlgoTraining.Topics.S04T07;

[Lesson("04-recursion-sorting-searching/07-selection-and-order-statistics", "Порядковые статистики и выбор k-го элемента")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(5, Canonical.Select([9, 2, 7, 4, 5], 3), "Медиана чеков");
        int[] latencies = [4, 1, 4, 2];
        Check.Equal(4, Modern.Select(latencies, 3, new Random(42)), "Третий результат измерений");
        Check.Throws<ArgumentOutOfRangeException>(() => Canonical.Select([], 1), "Недопустимый ранг");
    }
}
