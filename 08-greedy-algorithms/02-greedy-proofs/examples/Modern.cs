namespace AlgoTraining.Topics.S08T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static long CompletionSum(IEnumerable<int> durations)
    {
        return durations.Order().Aggregate((Elapsed: 0L, Total: 0L), (state, duration) =>
        {
            ArgumentOutOfRangeException.ThrowIfNegative(duration);
            var elapsed = state.Elapsed + duration;
            return (elapsed, state.Total + elapsed);
        }).Total;
    }
}
