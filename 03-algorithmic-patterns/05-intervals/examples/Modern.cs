namespace AlgoTraining.Topics.S03T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public readonly record struct Meeting(int Start, int End);
public static class Modern
{
    public static int Rooms(IEnumerable<Meeting> meetings)
    {
        var events = meetings.SelectMany(meeting =>
        {
            if (meeting.Start >= meeting.End)
                throw new ArgumentException("Нужна положительная длительность.");
            return new[] { (Time: meeting.Start, Delta: 1), (Time: meeting.End, Delta: -1) };
        }).OrderBy(item => item.Time).ThenBy(item => item.Delta);
        var active = 0;
        var best = 0;
        foreach (var item in events)
        {
            active += item.Delta;
            best = Math.Max(best, active);
        }
        return best; // Окончания (-1) раньше начал (+1). O(n log n), O(n).
    }
}
