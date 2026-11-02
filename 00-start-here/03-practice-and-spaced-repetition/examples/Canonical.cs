namespace AlgoTraining.Topics.S00T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Учебное расписание, а не научно подобранная модель памяти. O(k) дат.
    public static DateTime[] Repetitions(DateTime start, int[] dayOffsets)
    {
        DateTime[] result = new DateTime[dayOffsets.Length];
        for (int i = 0; i < dayOffsets.Length; i++)
        {
            if (dayOffsets[i] < 0)
                throw new ArgumentOutOfRangeException(nameof(dayOffsets));
            result[i] = start.AddDays(dayOffsets[i]);
        }
        return result;
    }
}
