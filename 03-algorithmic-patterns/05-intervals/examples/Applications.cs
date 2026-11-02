namespace AlgoTraining.Topics.S03T05;

[Lesson("03-algorithmic-patterns/05-intervals", "Интервалы")]
public static class Applications
{
    public static void Run()
    {
        int[][] merged = Canonical.Merge([new[] { 1, 4 }, new[] { 2, 5 }, new[] { 6, 8 }]);
        Check.Sequence(new[] { 1, 5 }, merged[0], "Объединение бронирований");
        Check.Equal(2, Modern.Rooms([new(1, 3), new(2, 4), new(3, 5)]), "Переговорные");
        Check.Equal(0, Modern.Rooms([]), "Нет встреч");
    }
}
