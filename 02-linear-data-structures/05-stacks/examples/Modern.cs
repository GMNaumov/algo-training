namespace AlgoTraining.Topics.S02T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static bool Balanced(ReadOnlySpan<char> text)
    {
        Stack<char> opened = new();
        foreach (var symbol in text)
        {
            if (symbol is '(' or '[' or '{')
                opened.Push(symbol);
            else if (symbol is ')' or ']' or '}')
            {
                var required = symbol switch
                {
                    ')' => '(',
                    ']' => '[',
                    _ => '{'
                };
                if (!opened.TryPop(out var top) || top != required)
                    return false;
            }
        }
        return opened.Count == 0;
    }
}
