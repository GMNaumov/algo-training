namespace AlgoTraining.Topics.S09T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static BigInteger Choose(int n, int k)
    {
        if (n < 0 || k < 0 || k > n)
            throw new ArgumentOutOfRangeException(nameof(k));
        BigInteger[] row = new BigInteger[k + 1];
        row[0] = 1;
        for (int i = 1; i <= n; i++)
            for (int j = Math.Min(i, k); j >= 1; j--)
                row[j] += row[j - 1];
        return row[k]; // Паскаль: O(nk) сложений, k+1 больших чисел.
    }
    public static double ExactlyOneHead()
    {
        int favorable = 0;
        int total = 0;
        for (int first = 0; first <= 1; first++)
            for (int second = 0; second <= 1; second++)
            {
                total++;
                if (first + second == 1)
                    favorable++;
            }
        return (double)favorable / total;
    }
}
