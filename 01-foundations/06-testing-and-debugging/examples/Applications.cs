namespace AlgoTraining.Topics.S01T06;

[Lesson("01-foundations/06-testing-and-debugging", "Тестирование и отладка решений")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(false, Modern.HasDuplicates([]), "Пустой реестр");
        Check.Equal(true, Modern.HasDuplicates([7, 4, 7]), "Повтор заказа");
        // Дифференциальная проверка: быстрый алгоритм против независимого перебора.
        Random random = new(42);
        for (int test = 0; test < 20; test++)
        {
            int[] values = Enumerable.Range(0, test % 7).Select(_ => random.Next(-3, 4)).ToArray();
            Check.Equal(Canonical.HasDuplicates(values), Modern.HasDuplicates(values), $"Сверка {test}");
        }
    }
}
