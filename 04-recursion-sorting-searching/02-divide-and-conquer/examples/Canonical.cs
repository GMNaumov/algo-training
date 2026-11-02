namespace AlgoTraining.Topics.S04T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Половины сортируются независимо, затем сливаются. O(n log n), буфер O(n).
    public static int[] Sort(int[] input)
    {
        int[] values = (int[])input.Clone();
        int[] buffer = new int[values.Length];
        SortPart(values, buffer, 0, values.Length);
        return values;
    }
    private static void SortPart(int[] values, int[] buffer, int left, int right)
    {
        if (right - left <= 1)
            return;
        int middle = left + (right - left) / 2;
        SortPart(values, buffer, left, middle);
        SortPart(values, buffer, middle, right);
        int i = left;
        int j = middle;
        for (int write = left; write < right; write++)
        {
            // <= сохраняет порядок равных элементов из левой половины.
            if (j == right || (i < middle && values[i] <= values[j]))
                buffer[write] = values[i++];
            else
                buffer[write] = values[j++];
        }
        for (int write = left; write < right; write++)
            values[write] = buffer[write];
    }
}
