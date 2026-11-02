namespace AlgoTraining.Topics.S01T03;

[Lesson("01-foundations/03-recurrence-relations", "Рекуррентные соотношения")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(10L, Canonical.Sum([1, 2, 3, 4], 0, 4), "Объединение сумм филиалов");
        Check.Equal(15L, Modern.Sum([1, 2, 3, 4, 5]), "Нечётное число показаний");
        Check.Equal(0L, Modern.Sum([]), "Пустая подзадача");
    }
}
