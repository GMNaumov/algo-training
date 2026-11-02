namespace AlgoTraining.Topics.S02T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class IntStack
{
    private readonly List<int> items = new List<int>();
    public void Push(int value)
    {
        items.Add(value);
    }
    public int Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек пуст.");
        int last = items.Count - 1;
        int result = items[last];
        items.RemoveAt(last);
        return result;
    }
}
public static class Canonical
{
    // O(n) времени и памяти. В стеке только ещё не закрытые открытия.
    public static bool Balanced(string text)
    {
        Stack<char> opened = new Stack<char>();
        for (int i = 0; i < text.Length; i++)
        {
            char symbol = text[i];
            if (symbol == '(' || symbol == '[' || symbol == '{')
                opened.Push(symbol);
            else if (symbol == ')' || symbol == ']' || symbol == '}')
            {
                if (opened.Count == 0)
                    return false;
                char top = opened.Pop();
                if ((symbol == ')' && top != '(') || (symbol == ']' && top != '[') || (symbol == '}' && top != '{'))
                    return false;
            }
        }
        return opened.Count == 0;
    }
}
