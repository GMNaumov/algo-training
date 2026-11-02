namespace AlgoTraining.Topics.S07T06;

[Lesson("07-dynamic-programming/06-interval-dp", "Интервальное динамическое программирование")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(14L, Canonical.MergeCost([4, 2, 3]), "Объединение пачек документов");
        Check.Equal(9L, Modern.MergeCost([1, 2, 3]), "Сборка соседних партий");
        Check.Equal(0L, Modern.MergeCost([5]), "Одна готовая пачка");
    }
}
