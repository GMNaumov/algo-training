namespace AlgoTraining.Topics.S13T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Упражнение «пропущенный номер»: вход содержит все разные числа 1..n, кроме одного.
    public static int Missing(int n, int[] present)
    {
        if (n <= 0 || present.Length != n - 1)
            throw new ArgumentException("Неверная длина.");
        int result = 0;
        for (int i = 1; i <= n; i++)
            result ^= i;
        for (int i = 0; i < present.Length; i++)
            result ^= present[i];
        return result; // O(n), O(1). Уникальность и диапазон — предпосылки задачи.
    }
}
