namespace AlgoTraining.Topics.S13T01;

[Lesson("13-reference/01-complexity-cheatsheet", "Шпаргалка по сложности алгоритмов и структур данных")]
public static class Applications
{
    public static void Run()
    {
        int[] ids = Enumerable.Range(1, 1024).ToArray();
        Check.Equal(1023, Canonical.Search(ids, 1024, out int comparisons), "Номер заказа линейным поиском");
        Check.Equal(1024, comparisons, "Число линейных сравнений");
        var result = Modern.Search(ids, 1024);
        Check.Equal(1023, result.Index, "Номер заказа бинарным поиском");
        Check.Equal(true, result.Comparisons <= 11, "Логарифмическое число сравнений");
    }
}
