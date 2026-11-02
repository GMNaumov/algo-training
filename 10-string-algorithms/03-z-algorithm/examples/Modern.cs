namespace AlgoTraining.Topics.S10T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] Z<T>(ReadOnlySpan<T> text) where T : IEquatable<T>
    {
        int[] z = new int[text.Length];
        var left = 0;
        var right = 0;
        for (var i = 1; i < text.Length; i++)
        {
            z[i] = i < right ? Math.Min(right - i, z[i - left]) : 0;
            while (i + z[i] < text.Length && text[z[i]].Equals(text[i + z[i]]))
                z[i]++;
            if (i + z[i] > right)
                (left, right) = (i, i + z[i]);
        }
        return z;
    }
    public static int[] Find(string text, string pattern)
    {
        if (pattern.Length == 0)
            return [.. Enumerable.Range(0, text.Length + 1)];
        // Код UTF-16 не бывает -1: разделитель точно отсутствует во входе.
        int[] combined = [.. pattern.Select(c => (int)c), -1, .. text.Select(c => (int)c)];
        var z = Z<int>(combined);
        return [.. Enumerable.Range(0, text.Length).Where(i => z[pattern.Length + 1 + i] >= pattern.Length)];
    }
}
