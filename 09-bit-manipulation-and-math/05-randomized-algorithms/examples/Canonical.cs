namespace AlgoTraining.Topics.S09T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int Reservoir(int[] values, Random random)
    {
        if (values.Length == 0)
            throw new ArgumentException("Пустой поток.");
        int selected = values[0];
        for (int i = 1; i < values.Length; i++)
            if (random.Next(i + 1) == 0)
                selected = values[i];
        return selected; // Вероятность выбора i-й заявки 1/i. O(n), O(1).
    }
    public static void Shuffle(int[] values, Random random)
    {
        for (int i = values.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            int temporary = values[i];
            values[i] = values[j];
            values[j] = temporary;
        }
        // Фишер — Йетс: все перестановки равновероятны при равномерном генераторе. O(n).
    }
}
