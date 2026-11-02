namespace AlgoTraining.Topics.S11T02;

[Lesson("11-advanced-topics/02-segment-trees", "Дерево отрезков")]
public static class Applications
{
    public static void Run()
    {
        Canonical sales = new Canonical([2, 1, 3, 4]);
        Check.Equal(8L, sales.Sum(1, 4), "Отчёт продаж");
        sales.Set(2, 8);
        Check.Equal(15L, sales.Sum(0, 4), "Коррекция продажи");
        Modern<int> minimum = new([2, 1, 3, 4], int.MaxValue, Math.Min);
        Check.Equal(1, minimum.Query(1..4), "Минимальная нагрузка");
        minimum.Set(1, 6);
        Check.Equal(3, minimum.Query(1..4), "Обновлённый минимум");
        LazySum bonus = new(4);
        bonus.Add(0, 4, 5);
        bonus.Add(1, 3, 2);
        Check.Equal(24L, bonus.Sum(0, 4), "Массовые надбавки");
        Check.Equal(7L, bonus.Sum(2, 3), "Частичный запрос после ленивого обновления");
    }
}
