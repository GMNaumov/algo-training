namespace AlgoTraining.Topics.S04T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Общая граница false...true; вызывающий гарантирует монотонность и наличие true справа.
    public static long FirstTrue(long left, long right, Func<long, bool> fits)
    {
        if (left < 0 || right < left || !fits(right))
            throw new ArgumentException("Неверные границы.");
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (fits(middle))
                right = middle;
            else
                left = middle + 1;
        }
        return left;
    }
    public static long Capacity(int[] weights, int days)
    {
        if (weights.Length == 0 || days <= 0 || weights.Any(w => w <= 0))
            throw new ArgumentException("Неверный вход.");
        return FirstTrue(weights.Max(), weights.Sum(w => (long)w), limit => Canonical.Fits(weights, days, limit));
    }
}
