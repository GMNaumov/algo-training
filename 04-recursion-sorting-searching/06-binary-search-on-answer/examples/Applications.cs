namespace AlgoTraining.Topics.S04T06;

[Lesson("04-recursion-sorting-searching/06-binary-search-on-answer", "Бинарный поиск по ответу")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(6L, Canonical.Capacity([3, 2, 2, 4], 2), "Грузоподъёмность доставки");
        Check.Equal(3L, Modern.Capacity([1, 2, 3], 2), "Две смены курьера");
        Check.Equal(6L, Modern.Capacity([1, 2, 3], 1), "Одна смена");
    }
}
