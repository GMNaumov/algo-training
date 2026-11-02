namespace AlgoTraining.Topics.S04T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Capacity(int[] weights, int days)
    {
        if (weights.Length == 0 || days <= 0)
            throw new ArgumentException("Нужны посылки и положительное число дней.");
        long left = 0;
        long right = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if (weights[i] <= 0)
                throw new ArgumentException("Веса должны быть положительными.");
            left = Math.Max(left, weights[i]);
            right += weights[i];
        }
        while (left < right)
        {
            long middle = left + (right - left) / 2;
            if (Fits(weights, days, middle))
                right = middle;
            else
                left = middle + 1;
        }
        return left; // O(n log(sum)), O(1).
    }
    public static bool Fits(int[] weights, int days, long capacity)
    {
        int used = 1;
        long load = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if (weights[i] > capacity)
                return false;
            if (load + weights[i] > capacity)
            {
                used++;
                load = 0;
            }
            load += weights[i];
        }
        return used <= days;
    }
}
