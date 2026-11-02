namespace AlgoTraining.Topics.S03T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Массив пар [start,end). Касающиеся интервалы объединяем для компактного покрытия.
    public static int[][] Merge(int[][] intervals)
    {
        int[][] sorted = (int[][])intervals.Clone();
        Array.Sort(sorted, CompareStarts);
        List<int[]> result = new List<int[]>();
        for (int i = 0; i < sorted.Length; i++)
        {
            int start = sorted[i][0];
            int end = sorted[i][1];
            if (start >= end)
                throw new ArgumentException("Интервалы должны иметь положительную длину.");
            if (result.Count == 0 || start > result[result.Count - 1][1])
                result.Add(new int[] { start, end });
            else
                result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], end);
        }
        return result.ToArray(); // O(n log n), память O(n).
    }
    private static int CompareStarts(int[] a, int[] b)
    {
        return a[0].CompareTo(b[0]);
    }
}
