namespace AlgoTraining.Topics.S13T03;

[Lesson("13-reference/03-pattern-catalog", "Каталог паттернов решения задач")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(7L, Canonical.RangeSum([3, 5, 2, 6], 1, 3), "Разовый отчёт");
        Modern reports = new([3, 5, 2, 6]);
        Check.Equal(7L, reports.RangeSum(1..3), "Повторные отчёты по продажам");
        Check.Equal(16L, reports.RangeSum(..), "Сумма всего периода");
    }
}
