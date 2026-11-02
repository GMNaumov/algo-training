namespace AlgoTraining.Topics.S09T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int CountBits(uint mask) => BitOperations.PopCount(mask);
    public static int Single(IEnumerable<int> ids) => ids.Aggregate(0, (accumulator, id) => accumulator ^ id);
    public static bool IsPowerOfTwo(uint value) => BitOperations.IsPow2(value);
}
