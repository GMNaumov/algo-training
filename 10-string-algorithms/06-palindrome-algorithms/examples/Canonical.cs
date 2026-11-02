namespace AlgoTraining.Topics.S10T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int Longest(string text)
    {
        int best = 0;
        for (int center = 0; center < text.Length; center++)
        {
            best = Math.Max(best, Expand(center, center));
            best = Math.Max(best, Expand(center, center + 1));
        }
        return best;
        int Expand(int left, int right)
        {
            while (left >= 0 && right < text.Length && text[left] == text[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        } // O(n²), O(1) сверх стека фиксированной глубины.
    }
    public static bool[,] Table(string text)
    {
        bool[,] palindrome = new bool[text.Length, text.Length];
        for (int length = 1; length <= text.Length; length++)
            for (int left = 0; left + length <= text.Length; left++)
            {
                int right = left + length - 1;
                palindrome[left, right] = text[left] == text[right] && (length <= 2 || palindrome[left + 1, right - 1]);
            }
        return palindrome; // O(n²) времени и памяти, затем запрос за O(1).
    }
}
