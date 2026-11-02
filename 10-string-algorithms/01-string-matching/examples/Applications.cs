namespace AlgoTraining.Topics.S10T01;

[Lesson("10-string-algorithms/01-string-matching", "Поиск подстроки")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 0, 2 }, Canonical.Find("ababa", "aba"), "Код в журнале");
        Check.Sequence(new[] { 0, 1, 2 }, Modern.Find("aaaa", "aa"), "Перекрывающиеся сигналы");
        Check.Sequence(new[] { 0, 1, 2, 3 }, Modern.Find("abc", ""), "Пустой образец на границах");
    }
}
