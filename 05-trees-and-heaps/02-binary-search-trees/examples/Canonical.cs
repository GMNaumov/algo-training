namespace AlgoTraining.Topics.S05T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private sealed class Node
    {
        public int Key; public Node? Left; public Node? Right;
        public Node(int key)
        {
            Key = key;
        }
    }
    private Node? root;
    public void Add(int key)
    {
        root = Insert(root, key);
    }
    private static Node Insert(Node? node, int key)
    {
        if (node == null)
            return new Node(key);
        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);
        return node; // Равные ключи игнорируем: семантика множества.
    }
    public bool Contains(int key)
    {
        Node? node = root;
        while (node != null)
        {
            if (node.Key == key)
                return true;
            node = key < node.Key ? node.Left : node.Right;
        }
        return false;
    }
    public void Remove(int key)
    {
        root = Delete(root, key);
    }
    private static Node? Delete(Node? node, int key)
    {
        if (node == null)
            return null;
        if (key < node.Key)
            node.Left = Delete(node.Left, key);
        else if (key > node.Key)
            node.Right = Delete(node.Right, key);
        else
        {
            if (node.Left == null)
                return node.Right;
            if (node.Right == null)
                return node.Left;
            Node successor = node.Right;
            while (successor.Left != null)
                successor = successor.Left;
            node.Key = successor.Key;
            node.Right = Delete(node.Right, successor.Key);
        }
        return node;
    }
    // Операции O(h), худшее O(n), память дерева O(n), рекурсия O(h).
}
