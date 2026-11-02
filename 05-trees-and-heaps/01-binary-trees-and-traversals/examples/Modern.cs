namespace AlgoTraining.Topics.S05T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static IEnumerable<string> InOrder(Node? root)
    {
        Stack<Node> stack = new();
        var current = root;
        while (current is not null || stack.Count > 0)
        {
            while (current is not null)
            {
                stack.Push(current);
                current = current.Left;
            }
            current = stack.Pop();
            yield return current.Value;
            current = current.Right;
        } // Итератор O(n), явный стек O(h), все результаты сразу не хранит.
    }
}
