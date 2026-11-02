namespace AlgoTraining.Topics.S00T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // DateOnly явно обозначает календарную дату без времени и часового пояса.
    public static DateOnly[] Repetitions(DateOnly start, ReadOnlySpan<int> offsets)
    {
        List<DateOnly> dates = [];
        foreach (var days in offsets)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(days);
            dates.Add(start.AddDays(days));
        }
        return [.. dates];
    }
}
