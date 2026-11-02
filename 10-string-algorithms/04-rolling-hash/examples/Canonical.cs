namespace AlgoTraining.Topics.S10T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private const long Modulus = 1_000_000_007;
    private const long Basis = 911_382_323;
    private readonly long[] prefix;
    private readonly long[] powers;
    public Canonical(string text)
    {
        prefix = new long[text.Length + 1];
        powers = new long[text.Length + 1];
        powers[0] = 1;
        for (int i = 0; i < text.Length; i++)
        {
            prefix[i + 1] = (prefix[i] * Basis + text[i] + 1) % Modulus;
            powers[i + 1] = powers[i] * Basis % Modulus;
        }
    }
    public long Slice(int left, int right)
    {
        if (left < 0 || right < left || right >= prefix.Length)
            throw new ArgumentOutOfRangeException(nameof(left));
        return (prefix[right] - prefix[left] * powers[right - left] % Modulus + Modulus) % Modulus;
    }
    // O(n) подготовка и память, O(1) запрос. Это отпечаток, не доказательство равенства.
    public static int[] FindVerified(string text, string pattern)
    {
        Canonical source = new Canonical(text);
        Canonical sample = new Canonical(pattern);
        List<int> result = new List<int>();
        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            if (source.Slice(i, i + pattern.Length) != sample.Slice(0, pattern.Length))
                continue;
            bool equal = true;
            for (int j = 0; j < pattern.Length; j++)
                if (text[i + j] != pattern[j])
                {
                    equal = false;
                    break;
                }
            if (equal)
                result.Add(i);
        }
        return result.ToArray(); // Точная проверка исключает ошибки, но худшее время O(nm).
    }
}
