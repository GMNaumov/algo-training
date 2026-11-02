namespace AlgoTraining.Topics.S04T05;

[Lesson("04-recursion-sorting-searching/05-binary-search", "Бинарный поиск")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(2, Canonical.LowerBound([10, 20, 30, 30, 50], 30), "Первая подходящая цена");
        Check.Equal(1, Modern.LowerBound<DateOnly>([new(2026, 1, 1), new(2026, 2, 1)], new(2026, 1, 15)), "Ближайшая дата");
        Check.Equal(0, Canonical.LowerBound([], 5), "Пустой массив");
        Check.Equal(2, Modern.LowerBound<int>([1, 2], 3), "Позиция после конца");
    }
}
