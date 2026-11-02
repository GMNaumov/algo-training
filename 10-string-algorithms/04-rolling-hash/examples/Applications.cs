namespace AlgoTraining.Topics.S10T04;

[Lesson("10-string-algorithms/04-rolling-hash", "Полиномиальное хеширование")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 0, 2 }, Canonical.FindVerified("ababa", "aba"), "Поиск с точным подтверждением");
        Check.Sequence(new[] { 1 }, Canonical.FindVerified("xabz", "ab"), "Код внутри сообщения");
        Check.Equal(true, Modern.EqualVerified("документ", "документ"), "Сверка содержимого");
        Check.Equal(false, Modern.EqualVerified("аб", "ба"), "Порядок символов важен");
    }
}
