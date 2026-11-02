namespace AlgoTraining.Topics.S04T07;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int Select(Span<int> values, int rank, Random random)
    {
        if (rank < 1 || rank > values.Length)
            throw new ArgumentOutOfRangeException(nameof(rank));
        var target = rank - 1;
        var left = 0;
        var right = values.Length;
        while (true)
        {
            var pivot = values[random.Next(left, right)];
            var less = left;
            var scan = left;
            var greater = right;
            // Три области: < pivot, == pivot, > pivot. Вход переставляется.
            while (scan < greater)
            {
                if (values[scan] < pivot)
                {
                    (values[less], values[scan]) = (values[scan], values[less]);
                    less++;
                    scan++;
                }
                else if (values[scan] > pivot)
                {
                    greater--;
                    (values[scan], values[greater]) = (values[greater], values[scan]);
                }
                else
                    scan++;
            }
            if (target < less)
                right = less;
            else if (target >= greater)
                left = greater;
            else
                return pivot;
        } // Ожидаемо O(n), худшее O(n²); O(1) дополнительной памяти.
    }
}
