namespace AlgoTraining.Topics.S10T05;

[Lesson("10-string-algorithms/05-suffix-structures", "Суффиксные структуры данных")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 5, 3, 1, 0, 4, 2 }, Canonical.SuffixArray("banana"), "Индекс текста");
        Check.Sequence(new[] { 2, 0, 1 }, Modern.SuffixArray("aba"), "Другой индекс");
        Check.Sequence(new[] { 0, 1, 3, 0, 0, 2 }, Modern.Lcp("banana", Modern.SuffixArray("banana")), "Повторы документа");
        Check.Sequence(new[] { 0, 1, 0 }, Modern.Lcp("aba", Modern.SuffixArray("aba")), "Короткий повтор");
        SuffixTree tree = new SuffixTree("banana");
        Check.Equal(true, tree.Contains("ana"), "Подстрока через сжатые рёбра");
        Check.Equal(false, tree.Contains("apple"), "Отсутствующее слово");
        SuffixAutomaton index = new("ababa");
        Check.Equal(true, index.Contains("bab"), "Поиск по автомату");
        Check.Equal(false, index.Contains("abb"), "Несуществующий сигнал");
    }
}
