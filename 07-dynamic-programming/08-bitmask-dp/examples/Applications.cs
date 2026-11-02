namespace AlgoTraining.Topics.S07T08;

[Lesson("07-dynamic-programming/08-bitmask-dp", "Динамическое программирование по битовым маскам")]
public static class Applications
{
    public static void Run()
    {
        int[,] work = { { 3, 1 }, { 2, 4 } };
        Check.Equal(3L, Canonical.Assignment(work), "Распределение задач");
        Check.Equal(5L, Modern.Assignment(new int[,] { { 5 } }), "Один исполнитель");
        Check.Equal(6L, Modern.Tour(new int[,] { { 0, 1, 3 }, { 1, 0, 2 }, { 3, 2, 0 } }), "Объезд складов");
        Check.Equal(7L, Modern.Tour(new int[,] { { 0, 3 }, { 4, 0 } }), "Круговой рейс двух городов");
    }
}
