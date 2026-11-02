namespace AlgoTraining.Topics.S11T01;

[Lesson("11-advanced-topics/01-fenwick-trees", "Дерево Фенвика")]
public static class Applications
{
    public static void Run()
    {
        Canonical sales = new Canonical(4);
        int[] values = [3, 5, 2, 6];
        for (int i = 0; i < values.Length; i++)
            sales.Add(i, values[i]);
        Check.Equal(7L, sales.Sum(1, 3), "Продажи диапазона");
        sales.Add(1, 3);
        Check.Equal(10L, sales.Sum(1, 3), "Исправление продажи");
        Modern<decimal> money = new(2);
        money.Add(0, 1.25m);
        money.Add(1, 2.50m);
        Check.Equal(3.75m, money.Prefix(2), "Денежные суммы без double");
        Check.Equal(0L, sales.Sum(2, 2), "Пустой диапазон");
    }
}
