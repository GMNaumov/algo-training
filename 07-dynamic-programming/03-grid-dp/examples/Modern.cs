namespace AlgoTraining.Topics.S07T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static BigInteger Paths(bool[,] blocked)
    {
        var rows = blocked.GetLength(0);
        var columns = blocked.GetLength(1);
        if (rows == 0 || columns == 0)
            return 0;
        BigInteger[] ways = new BigInteger[columns];
        ways[0] = 1;
        for (var r = 0; r < rows; r++)
            for (var c = 0; c < columns; c++)
                if (blocked[r, c])
                    ways[c] = 0;
                else if (c > 0)
                    ways[c] += ways[c - 1];
        return ways[^1]; // O(RC) сложений, C больших чисел вместо полной таблицы.
    }
}
