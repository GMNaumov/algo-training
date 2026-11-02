namespace AlgoTraining.Topics.S05T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Node
{
    public string Value;
    public Node? Left;
    public Node? Right;
    public Node(string value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}
public static class Canonical
{
    public static void Traverse(Node? node, List<string> result, string order)
    {
        if (order != "pre" && order != "in" && order != "post")
            throw new ArgumentException("Неизвестный обход.");
        if (node == null)
            return;
        if (order == "pre")
            result.Add(node.Value);
        Traverse(node.Left, result, order);
        if (order == "in")
            result.Add(node.Value);
        Traverse(node.Right, result, order);
        if (order == "post")
            result.Add(node.Value);
        // O(n), стек O(h), результат O(n).
    }
    public static string[] BreadthFirst(Node? root)
    {
        List<string> result = new List<string>();
        Queue<Node> queue = new Queue<Node>();
        if (root != null)
            queue.Enqueue(root);
        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();
            result.Add(node.Value);
            if (node.Left != null)
                queue.Enqueue(node.Left);
            if (node.Right != null)
                queue.Enqueue(node.Right);
        }
        return result.ToArray(); // O(n), очередь O(w).
    }
}
