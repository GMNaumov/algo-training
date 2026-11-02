namespace AlgoTraining.Topics.S02T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Node
{
    public int Value;
    public Node? Next;
    public Node(int value, Node? next = null)
    {
        Value = value;
        Next = next;
    }
}
public static class Canonical
{
    public static void InsertAfter(Node node, int value)
    {
        Node added = new Node(value);
        added.Next = node.Next; // Сначала сохраняем хвост, затем меняем старую связь.
        node.Next = added;
    }
    public static Node? Reverse(Node? head)
    {
        Node? previous = null;
        Node? current = head;
        while (current != null)
        {
            Node? next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        return previous; // O(n), дополнительная память O(1).
    }
}
