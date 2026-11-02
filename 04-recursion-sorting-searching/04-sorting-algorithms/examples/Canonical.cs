namespace AlgoTraining.Topics.S04T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static void Insertion(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            int value = a[i];
            int j = i - 1;
            while (j >= 0 && a[j] > value)
            {
                a[j + 1] = a[j];
                j--;
            }
            a[j + 1] = value;
        } // O(n²), O(1); уже упорядоченный вход O(n).
    }
    public static void Selection(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            int best = i;
            for (int j = i + 1; j < a.Length; j++)
                if (a[j] < a[best])
                    best = j;
            Swap(a, i, best);
        } // O(n²), O(1).
    }
    public static void Merge(int[] a)
    {
        int[] sorted = S04T02.Canonical.Sort(a);
        Array.Copy(sorted, a, a.Length); // Реализация слияния находится в соседней теме.
    }
    public static void Quick(int[] a)
    {
        QuickPart(a, 0, a.Length - 1);
    }
    private static void QuickPart(int[] a, int left, int right)
    {
        if (left >= right)
            return;
        int pivot = a[left + (right - left) / 2];
        int i = left;
        int j = right;
        while (i <= j)
        {
            while (a[i] < pivot)
                i++;
            while (a[j] > pivot)
                j--;
            if (i <= j)
            {
                Swap(a, i, j);
                i++;
                j--;
            }
        }
        QuickPart(a, left, j);
        QuickPart(a, i, right);
        // Фиксированный pivot: худшее O(n²), стек до O(n), среднее зависит от входа.
    }
    public static void Heap(int[] a)
    {
        for (int root = a.Length / 2 - 1; root >= 0; root--)
            Down(a, root, a.Length);
        for (int size = a.Length - 1; size > 0; size--)
        {
            Swap(a, 0, size);
            Down(a, 0, size);
        }
    }
    private static void Down(int[] a, int root, int size)
    {
        while (root < size / 2)
        {
            int child = 2 * root + 1;
            if (child + 1 < size && a[child + 1] > a[child])
                child++;
            if (a[root] >= a[child])
                break;
            Swap(a, root, child);
            root = child;
        } // Пирамидальная: O(n log n), O(1).
    }
    public static void Counting(int[] a, int maximum)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(maximum);
        int[] counts = new int[checked(maximum + 1)];
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < 0 || a[i] > maximum)
                throw new ArgumentOutOfRangeException(nameof(a));
            counts[a[i]]++;
        }
        int write = 0;
        for (int value = 0; value <= maximum; value++)
            for (int copy = 0; copy < counts[value]; copy++)
                a[write++] = value;
        // O(n+U), O(U). Этот вариант сортирует числа, стабильность записей не обещает.
    }
    private static void Swap(int[] a, int i, int j)
    {
        int value = a[i];
        a[i] = a[j];
        a[j] = value;
    }
}
