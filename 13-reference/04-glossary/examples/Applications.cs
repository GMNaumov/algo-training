namespace AlgoTraining.Topics.S13T04;

[Lesson("13-reference/04-glossary", "Глоссарий")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(true, Canonical.IsSubsequence("ace", "abcde"), "Подпоследовательность текста");
        Check.Equal(false, "abcde".Contains("ace", StringComparison.Ordinal), "Та же строка не подстрока");
        Check.Equal(true, Modern.IsSubsequence<int>([1, 3], [1, 2, 3, 4]), "Порядок событий API");
        Check.Equal(false, Modern.IsSubsequence<int>([3, 1], [1, 2, 3]), "Порядок сохраняется");
    }
}
