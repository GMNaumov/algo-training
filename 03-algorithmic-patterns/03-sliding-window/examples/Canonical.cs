namespace AlgoTraining.Topics.S03T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long MaxSum(int[] values, int size)
    {
        if (size <= 0 || size > values.Length)
            throw new ArgumentOutOfRangeException(nameof(size));
        long sum = 0;
        for (int i = 0; i < size; i++)
            sum += values[i];
        long best = sum;
        for (int i = size; i < values.Length; i++)
        {
            sum = sum - values[i - size] + values[i];
            if (sum > best)
                best = sum;
        }
        return best; // O(n), O(1); отрицательные значения допустимы.
    }
    public static int LongestWithinBudget(int[] durations, long budget)
    {
        if (budget < 0)
            throw new ArgumentOutOfRangeException(nameof(budget));
        int left = 0;
        int best = 0;
        long sum = 0;
        for (int right = 0; right < durations.Length; right++)
        {
            if (durations[right] < 0)
                throw new ArgumentException("Нужны неотрицательные длительности.");
            sum += durations[right];
            while (sum > budget)
            {
                sum -= durations[left];
                left++;
            }
            best = Math.Max(best, right - left + 1);
        }
        return best; // Границы движутся только вперёд: O(n), O(1).
    }
}
