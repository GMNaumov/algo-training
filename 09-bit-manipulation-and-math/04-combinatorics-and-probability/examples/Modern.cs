namespace AlgoTraining.Topics.S09T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static BigInteger Choose(int n, int k)
    {
        if (n < 0 || k < 0 || k > n)
            throw new ArgumentOutOfRangeException(nameof(k));
        k = Math.Min(k, n - k);
        BigInteger result = 1;
        for (var i = 1; i <= k; i++)
            result = result * (n - k + i) / i;
        return result; // O(k) операций над BigInteger, каждое деление точное.
    }
    public static double ExpectedHeads(int fairCoins)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(fairCoins);
        return fairCoins * 0.5; // Линейность ожидания.
    }
}
