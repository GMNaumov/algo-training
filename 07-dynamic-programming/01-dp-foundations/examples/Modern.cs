namespace AlgoTraining.Topics.S07T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static BigInteger Stairs(int steps)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(steps);
        BigInteger previous = 1;
        BigInteger current = 1;
        for (var i = 1; i <= steps; i++)
            (previous, current) = (current, previous + current);
        return previous; // O(n) сложений, две переменные; разрядность BigInteger растёт с n.
    }
}
