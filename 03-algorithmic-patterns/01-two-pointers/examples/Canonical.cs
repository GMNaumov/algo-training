namespace AlgoTraining.Topics.S03T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Вход отсортирован. При маленькой сумме левый элемент бесполезен для всех партнёров.
    public static int[] FindPair(int[] sorted, long target)
    {
        int left = 0;
        int right = sorted.Length - 1;
        while (left < right)
        {
            long sum = (long)sorted[left] + sorted[right];
            if (sum == target)
                return new int[] { left, right };
            if (sum < target)
                left++;
            else
                right--;
        }
        return new int[0]; // O(n), O(1) без результата.
    }
}
