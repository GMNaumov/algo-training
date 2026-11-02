namespace AlgoTraining.Topics.S01T01;

[Lesson("01-foundations/01-complexity-analysis", "Анализ сложности и Big O")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(6L, Canonical.PairComparisons(4), "Пары четырёх чеков");
        Check.Equal(4_999_950_000L, Modern.PairComparisons(100_000), "Оценка сверки заказов");
        Check.Equal(0L, Modern.PairComparisons(0), "Пустая коллекция");
    }
}
