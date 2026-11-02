namespace AlgoTraining.Topics.S09T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Gcd(int first, int second)
    {
        long a = Math.Abs((long)first);
        long b = Math.Abs((long)second);
        while (b != 0)
        {
            long remainder = a % b;
            a = b;
            b = remainder;
        }
        return a; // Соглашение gcd(0,0)=0. O(log min), O(1).
    }
    public static long Lcm(int first, int second)
    {
        if (first == 0 || second == 0)
            return 0;
        return Math.Abs((long)first / Gcd(first, second) * second);
    }
    public static bool IsPrime(int value)
    {
        if (value < 2)
            return false;
        for (int divisor = 2; divisor <= value / divisor; divisor++)
            if (value % divisor == 0)
                return false;
        return true; // O(sqrt(n)), O(1). Не вычисляем потенциально опасное divisor².
    }
    public static int[] Sieve(int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);
        bool[] composite = new bool[checked(limit + 1)];
        for (int p = 2; p <= limit / p; p++)
            if (!composite[p])
                for (long multiple = (long)p * p; multiple <= limit; multiple += p)
                    composite[(int)multiple] = true;
        List<int> primes = new List<int>();
        for (int i = 2; i <= limit; i++)
            if (!composite[i])
                primes.Add(i);
        return primes.ToArray(); // O(n log log n), O(n).
    }
}
