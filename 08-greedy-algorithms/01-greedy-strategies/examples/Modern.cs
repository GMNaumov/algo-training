namespace AlgoTraining.Topics.S08T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public readonly record struct Meeting(int Start, int End);
public static class Modern
{
    public static Meeting[] Attend(IEnumerable<Meeting> meetings)
    {
        List<Meeting> result = [];
        long end = long.MinValue;
        foreach (var meeting in meetings.OrderBy(m => m.End))
        {
            if (meeting.Start >= meeting.End)
                throw new ArgumentException("Неверная встреча.");
            if (meeting.Start < end)
                continue;
            result.Add(meeting);
            end = meeting.End;
        }
        return [.. result];
    }
}
