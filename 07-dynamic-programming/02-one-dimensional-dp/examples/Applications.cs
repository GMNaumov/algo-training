namespace AlgoTraining.Topics.S07T02;

[Lesson("07-dynamic-programming/02-one-dimensional-dp", "Одномерное динамическое программирование")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(13L, Canonical.NonAdjacent([4, 1, 1, 9]), "Доход без соседних смен");
        Check.Equal(12L, Modern.NonAdjacent([2, 7, 9, 3, 1]), "Расписание рекламных дней");
        Check.Equal(5L, Canonical.MaxSubarray([-3, 4, -1, 2, -5]), "Лучший непрерывный период");
        Check.Equal(-2L, Modern.MaxSubarray([-7, -2, -9]), "Наименьший убыток");
    }
}
