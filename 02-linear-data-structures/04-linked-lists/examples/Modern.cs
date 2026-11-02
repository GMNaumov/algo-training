namespace AlgoTraining.Topics.S02T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static Node? Reverse(Node? head)
    {
        Node? previous = null;
        while (head is { } current)
        {
            // Правая часть вычисляется до присваивания: ссылка на остаток не теряется.
            (head, current.Next, previous) = (current.Next, previous, current);
        }
        return previous;
    }
    public static IEnumerable<int> Values(Node? head)
    {
        for (var node = head; node is not null; node = node.Next)
            yield return node.Value;
    }
}
