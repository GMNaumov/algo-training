namespace AlgoTraining.Topics.S02T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Кодовые точки поддерживают emoji; нормализация и графемы — отдельные требования.
    // LINQ Reverse буферизует последовательность: O(n) времени и памяти.
    public static bool IsPalindrome(string text)
    {
        var runes = text.EnumerateRunes().ToArray();
        return runes.SequenceEqual(runes.Reverse());
    }
    public static string JoinWords(IEnumerable<string> words) => string.Join(" ", words);
}
