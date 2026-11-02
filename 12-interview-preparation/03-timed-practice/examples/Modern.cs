namespace AlgoTraining.Topics.S12T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed record Measurement<T>(T Value, TimeSpan Elapsed);
public static class Modern
{
    public static Measurement<T> Measure<T>(Func<T> action)
    {
        var started = Stopwatch.GetTimestamp();
        var result = action();
        return new(result, Stopwatch.GetElapsedTime(started));
    }
}
