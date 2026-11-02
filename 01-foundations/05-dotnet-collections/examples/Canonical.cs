namespace AlgoTraining.Topics.S01T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Явное обновление словаря: ожидаемо O(n), память O(u) различных клиентов.
    public static Dictionary<string, int> Frequencies(string[] clients)
    {
        Dictionary<string, int> result = new Dictionary<string, int>(StringComparer.Ordinal);
        for (int i = 0; i < clients.Length; i++)
        {
            int count;
            if (result.TryGetValue(clients[i], out count))
                result[clients[i]] = count + 1;
            else
                result.Add(clients[i], 1);
        }
        return result;
    }
}
