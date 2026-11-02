namespace AlgoTraining.Topics.S03T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Node
{
    public int Value;
    public Node? Next;
    public Node(int value)
    {
        Value = value;
    }
}
public static class Canonical
{
    public static Node? CycleEntry(Node? head)
    {
        Node? slow = head;
        Node? fast = head;
        while (fast != null && fast.Next != null)
        {
            slow = slow!.Next;
            fast = fast.Next.Next;
            if (ReferenceEquals(slow, fast))
            {
                Node? entry = head;
                while (!ReferenceEquals(entry, slow))
                {
                    entry = entry!.Next;
                    slow = slow!.Next;
                }
                return entry;
            }
        }
        return null; // O(n), O(1). Сравниваем сами узлы, не их значения.
    }
    public static Node? Middle(Node? head)
    {
        Node? slow = head;
        Node? fast = head;
        while (fast != null && fast.Next != null)
        {
            slow = slow!.Next;
            fast = fast.Next.Next;
        }
        return slow; // Для чётной длины выбран правый средний. Вход без цикла.
    }
}
