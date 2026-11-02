namespace AlgoTraining.Topics.S01T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static bool HasDuplicates(ReadOnlySpan<int> values)
    {
        HashSet<int> seen = [];
        foreach (var value in values)
            if (!seen.Add(value))
                return true;
        return false; // Ожидаемо O(n), память O(n).
    }
}
