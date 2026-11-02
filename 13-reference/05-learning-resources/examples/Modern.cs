namespace AlgoTraining.Topics.S13T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int Missing(int n, IEnumerable<int> present)
    {
        if (n <= 0)
            throw new ArgumentOutOfRangeException(nameof(n));
        var items = present.ToArray();
        if (items.Length != n - 1 || items.Any(x => x < 1 || x > n) || items.Distinct().Count() != items.Length)
            throw new ArgumentException("Нужны разные числа из диапазона.");
        return Enumerable.Range(1, n).Except(items).Single();
        // Ожидаемо O(n), O(n): лаконичность LINQ оплачивается хеш-множеством.
    }
}
