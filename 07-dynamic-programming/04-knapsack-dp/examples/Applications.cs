namespace AlgoTraining.Topics.S07T04;

[Lesson("07-dynamic-programming/04-knapsack-dp", "Задачи о рюкзаке")]
public static class Applications
{
    public static void Run()
    {
        int[] weights = [2, 3, 4];
        int[] benefits = [3, 4, 5];
        Check.Equal(7L, Canonical.ZeroOne(weights, benefits, 5), "Оборудование курьера");
        Check.Equal(5L, Modern.ZeroOne(weights, benefits, 4), "Бюджет уникальных покупок");
        Check.Equal(6L, Canonical.Unlimited(weights, benefits, 4), "Повторяемые упаковки");
        Check.Equal(9L, Canonical.Unlimited([2], [3], 6), "Закупка одинаковых комплектов");
    }
}
