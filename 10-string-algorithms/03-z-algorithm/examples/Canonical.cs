namespace AlgoTraining.Topics.S10T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] Z(string text)
    {
        int[] z = new int[text.Length];
        int left = 0;
        int right = 0;
        for (int i = 1; i < text.Length; i++)
        {
            if (i < right)
                z[i] = Math.Min(right - i, z[i - left]);
            while (i + z[i] < text.Length && text[z[i]] == text[i + z[i]])
                z[i]++;
            if (i + z[i] > right)
            {
                left = i;
                right = i + z[i];
            }
        }
        return z; // [left,right), Z[0]=0. O(n), O(n).
    }
}
