namespace AlgoTraining.Topics.S03T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Альтернатива с HashSet понятнее, но платит O(n) памяти за посещённые узлы.
    public static Node? CycleEntry(Node? head)
    {
        HashSet<Node> seen = new(ReferenceEqualityComparer.Instance);
        while (head is { } node)
        {
            if (!seen.Add(node))
                return node;
            head = node.Next;
        }
        return null;
    }
}
