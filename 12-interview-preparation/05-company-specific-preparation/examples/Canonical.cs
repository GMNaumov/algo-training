namespace AlgoTraining.Topics.S12T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Учебная эвристика планирования, не прогноз вопросов работодателя.
    public static string NextTopic(string[] topics, int[] requirements, int[] readiness)
    {
        if (topics.Length == 0 || topics.Length != requirements.Length || topics.Length != readiness.Length)
            throw new ArgumentException("Неверные списки.");
        int best = 0;
        long priority = long.MinValue;
        for (int i = 0; i < topics.Length; i++)
        {
            long current = (long)requirements[i] - readiness[i];
            if (current > priority)
            {
                priority = current;
                best = i;
            }
        }
        return topics[best]; // O(n), O(1), при равенстве сохраняем первую тему.
    }
}
