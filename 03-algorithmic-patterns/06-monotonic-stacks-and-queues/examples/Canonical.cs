namespace AlgoTraining.Topics.S03T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Warmer(int[] temperatures)
    {
        int[] stack = new int[temperatures.Length];
        int count = 0;
        int[] result = new int[temperatures.Length];
        for (int day = 0; day < temperatures.Length; day++)
        {
            while (count > 0 && temperatures[stack[count - 1]] < temperatures[day])
            {
                int previous = stack[--count];
                result[previous] = day - previous;
            }
            stack[count++] = day;
        }
        return result; // Каждый индекс добавлен и удалён не более раза: O(n), O(n).
    }
    public static int[] MaxWindows(int[] values, int size)
    {
        if (size <= 0 || size > values.Length)
            throw new ArgumentOutOfRangeException(nameof(size));
        int[] deque = new int[values.Length];
        int first = 0;
        int end = 0;
        int[] result = new int[values.Length - size + 1];
        for (int i = 0; i < values.Length; i++)
        {
            while (first < end && deque[first] <= i - size)
                first++;
            while (first < end && values[deque[end - 1]] <= values[i])
                end--;
            deque[end++] = i;
            if (i >= size - 1)
                result[i - size + 1] = values[deque[first]];
        }
        return result; // O(n); учебный линейный буфер O(n), активных индексов O(size).
    }
}
