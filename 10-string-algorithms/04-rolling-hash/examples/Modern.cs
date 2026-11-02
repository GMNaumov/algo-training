namespace AlgoTraining.Topics.S10T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public readonly record struct Fingerprint(long First, long Second, int Length);
public static class Modern
{
    public static Fingerprint Hash(ReadOnlySpan<char> text)
    {
        long first = 0, second = 0;
        foreach (var symbol in text)
        {
            first = (first * 911_382_323 + symbol + 1) % 1_000_000_007;
            second = (second * 972_663_749 + symbol + 1) % 1_000_000_009;
        }
        return new(first, second, text.Length); // O(L). Два хеша снижают риск, но не убирают коллизии.
    }
    public static bool EqualVerified(ReadOnlySpan<char> a, ReadOnlySpan<char> b) => Hash(a) == Hash(b) && a.SequenceEqual(b);
}
