namespace AlgoTraining.Topics.S10T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[] SuffixArray(string text)
    {
        int[] suffixes = new int[text.Length];
        for (int i = 0; i < text.Length; i++)
            suffixes[i] = i;
        Array.Sort(suffixes, Compare);
        return suffixes;
        int Compare(int a, int b)
        {
            int commonLength = Math.Min(text.Length - a, text.Length - b);
            int result = string.CompareOrdinal(text, a, text, b, commonLength);
            return result != 0 ? result : (text.Length - a).CompareTo(text.Length - b);
        } // Простая сортировка сравнением: O(n² log n) верхняя оценка, O(n) массива.
    }
}
// Наивное сжатое суффиксное дерево: строим все суффиксы и делим рёбра.
// Метки — строки-копии, поэтому построение и хранение могут быть квадратичными.
public sealed class SuffixTree
{
    private sealed class Node
    {
        public Dictionary<char, Edge> Edges = new Dictionary<char, Edge>(); public bool End;
    }
    private sealed class Edge
    {
        public string Label; public Node Next; public Edge(string label, Node next)
        {
            Label = label;
            Next = next;
        }
    }
    private readonly Node root = new Node();
    public SuffixTree(string text)
    {
        for (int i = 0; i < text.Length; i++)
            Insert(root, text.Substring(i));
    }
    private static void Insert(Node node, string suffix)
    {
        if (suffix.Length == 0)
        {
            node.End = true;
            return;
        }
        Edge? edge;
        if (!node.Edges.TryGetValue(suffix[0], out edge))
        {
            node.Edges.Add(suffix[0], new Edge(suffix, new Node { End = true }));
            return;
        }
        int common = 0;
        while (common < suffix.Length && common < edge.Label.Length && suffix[common] == edge.Label[common])
            common++;
        if (common == edge.Label.Length)
        {
            Insert(edge.Next, suffix.Substring(common));
            return;
        }
        Node branch = new Node();
        branch.Edges.Add(edge.Label[common], new Edge(edge.Label.Substring(common), edge.Next));
        edge.Label = edge.Label.Substring(0, common);
        edge.Next = branch;
        Insert(branch, suffix.Substring(common));
    }
    public bool Contains(string pattern)
    {
        Node node = root;
        int offset = 0;
        while (offset < pattern.Length)
        {
            Edge? edge;
            if (!node.Edges.TryGetValue(pattern[offset], out edge))
                return false;
            for (int j = 0; j < edge.Label.Length && offset < pattern.Length; j++, offset++)
                if (edge.Label[j] != pattern[offset])
                    return false;
            node = edge.Next;
        }
        return true; // Ожидаемо O(m) поиска; пустая строка содержится всегда.
    }
}
