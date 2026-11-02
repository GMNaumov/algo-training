namespace AlgoTraining.Topics.S02T01;

[Lesson("02-linear-data-structures/01-arrays", "Массивы")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 5, 8, 4, 3 }, Canonical.Insert([5, 8, 3], 2, 4), "Пропущенный день продаж");
        Check.Sequence(new[] { 10, 20, 30 }, Modern.Insert([10, 30], 1, 20), "Новая позиция расписания");
        Check.Sequence(new[] { 5, 3 }, Canonical.Remove([5, 8, 3], 1), "Удаление дня");
        Check.Sequence(new[] { 7 }, Modern.Insert([], 0, 7), "Первый элемент");
    }
}
