namespace AlgoTraining.Topics.S10T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int Longest(ReadOnlySpan<char> text)
    {
        int[] odd = new int[text.Length];
        int[] even = new int[text.Length];
        var left = 0;
        var right = -1;
        var best = 0;
        for (var i = 0; i < text.Length; i++)
        {
            var radius = i > right ? 1 : Math.Min(odd[left + right - i], right - i + 1);
            while (i - radius >= 0 && i + radius < text.Length && text[i - radius] == text[i + radius])
                radius++;
            odd[i] = radius;
            best = Math.Max(best, 2 * radius - 1);
            if (i + radius - 1 > right)
                (left, right) = (i - radius + 1, i + radius - 1);
        }
        (left, right) = (0, -1);
        for (var i = 0; i < text.Length; i++)
        {
            var radius = i > right ? 0 : Math.Min(even[left + right - i + 1], right - i + 1);
            while (i - radius - 1 >= 0 && i + radius < text.Length && text[i - radius - 1] == text[i + radius])
                radius++;
            even[i] = radius;
            best = Math.Max(best, 2 * radius);
            if (i + radius - 1 > right)
                (left, right) = (i - radius, i + radius - 1);
        }
        return best; // Манакер O(n), O(n). Обе чётности; единица текста — char.
    }
}
