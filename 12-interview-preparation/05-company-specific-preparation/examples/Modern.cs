namespace AlgoTraining.Topics.S12T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed record Preparation(string Topic, int Requirement, int Readiness, string Source)
{
    public long Gap => (long)Requirement - Readiness;
}
public static class Modern
{
    public static Preparation[] Plan(IEnumerable<Preparation> items) =>
        items.OrderByDescending(item => item.Gap).ThenBy(item => item.Topic, StringComparer.Ordinal).ToArray();
    // O(n log n), O(n). Source хранит основание требования, а не догадку о компании.
}
