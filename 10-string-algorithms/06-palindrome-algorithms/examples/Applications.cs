namespace AlgoTraining.Topics.S10T06;

[Lesson("10-string-algorithms/06-palindrome-algorithms", "Алгоритмы для палиндромов")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(5, Canonical.Longest("ababa"), "Симметрия сигнала");
        Check.Equal(4, Modern.Longest("abba"), "Чётный палиндром");
        Check.Equal(0, Modern.Longest(""), "Пустой текст");
        Check.Equal(true, Canonical.Table("ababa")[1, 3], "Проверка фрагмента bab");
        Check.Equal(false, Canonical.Table("abc")[0, 2], "Несимметричный фрагмент");
    }
}
