namespace AlgoTraining.Topics.S12T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Трасса помогает объяснить инвариант вместо пересказа каждой строки.
    public static string[] ExplainMaximum(int[] values)
    {
        if (values.Length == 0)
            throw new ArgumentException("Максимум пустого набора не определён.");
        List<string> trace = new List<string>();
        int best = values[0];
        for (int i = 0; i < values.Length; i++)
        {
            best = Math.Max(best, values[i]);
            trace.Add("Просмотрено: " + (i + 1) + "; максимум: " + best);
        }
        return trace.ToArray(); // O(n) времени и памяти именно для объясняющей трассы.
    }
}
