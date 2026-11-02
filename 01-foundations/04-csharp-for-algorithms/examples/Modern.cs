namespace AlgoTraining.Topics.S01T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long Sum(IEnumerable<int> receipts) => receipts.Sum(value => (long)value);
    // Rune обходит кодовые точки Unicode; это всё ещё не обязательно видимые графемы.
    public static int CodePoints(string text) => text.EnumerateRunes().Count();
}
