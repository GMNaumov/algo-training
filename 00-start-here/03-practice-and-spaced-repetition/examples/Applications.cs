namespace AlgoTraining.Topics.S00T03;

[Lesson("00-start-here/03-practice-and-spaced-repetition", "Практика и интервальное повторение")]
public static class Applications
{
    public static void Run()
    {
        DateTime start = new DateTime(2026, 11, 2);
        Check.Equal(start.AddDays(7), Canonical.Repetitions(start, [1, 3, 7])[2], "Повторение массивов");
        Check.Equal(new DateOnly(2026, 11, 5), Modern.Repetitions(new(2026, 11, 2), [1, 3])[1], "Повторение ошибок");
    }
}
