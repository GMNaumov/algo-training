namespace AlgoTraining.Topics.S02T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // Для текста из простых букв. Сравниваем UTF-16 char: O(n), O(1).
    public static bool IsPalindrome(string text)
    {
        int left = 0;
        int right = text.Length - 1;
        while (left < right)
        {
            if (text[left] != text[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}
