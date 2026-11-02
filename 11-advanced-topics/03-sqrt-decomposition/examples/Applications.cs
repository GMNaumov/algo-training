namespace AlgoTraining.Topics.S11T03;

[Lesson("11-advanced-topics/03-sqrt-decomposition", "Корневая декомпозиция")]
public static class Applications
{
    public static void Run()
    {
        Canonical sales = new Canonical([1, 2, 3, 4, 5, 6, 7, 8, 9]);
        Check.Equal(35L, sales.Sum(1, 8), "Отчёт по датам");
        sales.Set(4, 10);
        Check.Equal(40L, sales.Sum(1, 8), "Обновлённые данные");
        Modern stock = new([8, 2, 5, 1, 7]);
        Check.Equal(1, stock.Minimum(0..5), "Минимальный остаток");
        stock.Set(3, 9);
        Check.Equal(2, stock.Minimum(0..5), "Пересчёт минимального блока");
    }
}
