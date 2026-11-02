namespace AlgoTraining.Topics.S09T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static BigInteger Gcd(BigInteger a, BigInteger b) => BigInteger.GreatestCommonDivisor(a, b);
    public static IEnumerable<int> Primes(int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);
        // Ленивый перебор проще решета, но медленнее: O(n sqrt(n)) верхняя оценка.
        return Enumerable.Range(0, limit).Select(i => i + 1).Where(Canonical.IsPrime);
    }
}
