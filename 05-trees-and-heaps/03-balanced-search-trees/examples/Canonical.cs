namespace AlgoTraining.Topics.S05T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private sealed class Node
    {
        public int Key; public int Height = 1; public Node? Left; public Node? Right;
        public Node(int key)
        {
            Key = key;
        }
    }
    private Node? root;
    public int Height
    {
        get
        {
            return H(root);
        }
    }
    private static int H(Node? node)
    {
        return node == null ? 0 : node.Height;
    }
    private static void Update(Node node)
    {
        node.Height = 1 + Math.Max(H(node.Left), H(node.Right));
    }
    private static Node Right(Node node)
    {
        Node next = node.Left!;
        node.Left = next.Right;
        next.Right = node;
        Update(node);
        Update(next);
        return next;
    }
    private static Node Left(Node node)
    {
        Node next = node.Right!;
        node.Right = next.Left;
        next.Left = node;
        Update(node);
        Update(next);
        return next;
    }
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
        else
            return node;
        Update(node);
        int balance = H(node.Left) - H(node.Right);
        if (balance > 1)
        {
            if (key > node.Left!.Key)
                node.Left = Left(node.Left);
            return Right(node);
        }
        if (balance < -1)
        {
            if (key < node.Right!.Key)
                node.Right = Right(node.Right);
            return Left(node);
        }
        return node;
    }
    public bool Contains(int key)
    {
        Node? current = root;
        while (current != null)
        {
            if (current.Key == key)
                return true;
            current = key < current.Key ? current.Left : current.Right;
        }
        return false;
    }
    // AVL-вставка и поиск O(log n). Учебная реализация только этих операций.
}
