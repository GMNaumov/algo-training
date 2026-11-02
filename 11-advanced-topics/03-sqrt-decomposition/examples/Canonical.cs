namespace AlgoTraining.Topics.S11T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly int[] values; private readonly long[] sums; private readonly int block;
    public Canonical(int[] source)
    {
        values = (int[])source.Clone();
        block = Math.Max(1, (int)Math.Sqrt(values.Length));
        sums = new long[(values.Length + block - 1) / block];
        for (int i = 0; i < values.Length; i++)
            sums[i / block] += values[i];
    }
    public void Set(int index, int value)
    {
        if (index < 0 || index >= values.Length)
            throw new ArgumentOutOfRangeException(nameof(index));
        sums[index / block] += (long)value - values[index];
        values[index] = value;
    }
    public long Sum(int left, int right)
    {
        if (left < 0 || right < left || right > values.Length)
            throw new ArgumentOutOfRangeException(nameof(left));
        long sum = 0;
        while (left < right)
            if (left % block == 0 && right - left >= block)
            {
                sum += sums[left / block];
                left += block;
            }
            else
                sum += values[left++];
        return sum; // Запрос O(sqrt n), Set O(1), память O(n).
    }
}
