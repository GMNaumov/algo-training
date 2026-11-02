namespace AlgoTraining.Topics.S12T03;

[Lesson("12-interview-preparation/03-timed-practice", "Решение задач на время")]
public static class Applications
{
    public static void Run()
    {
        long total = 0;
        long ticks = Canonical.Measure(() => total = Canonical.Sum([2, 1, 5, 1, 3]));
        Check.Equal(12L, total, "Сумма продаж под таймером");
        Check.Equal(true, ticks >= 0, "Таймер вернул длительность");
        var run = Modern.Measure(() => S03T03.Canonical.MaxSum([2, 1, 5, 1, 3], 3));
        Check.Equal(9L, run.Value, "Окно в тренировочной сессии");
        // Не сравниваем длительность с жёстким порогом: JIT и нагрузка меняют время.
    }
}
