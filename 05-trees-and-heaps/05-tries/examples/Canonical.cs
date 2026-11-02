namespace AlgoTraining.Topics.S05T05;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private sealed class Node
    {
        public readonly Node?[] Children = new Node?[26]; public bool Word;
    }
    private readonly Node root = new Node();
    private static int Index(char symbol)
    {
        if (symbol < 'a' || symbol > 'z')
            throw new ArgumentException("Алфавит: a–z.");
        return symbol - 'a';
    }
    public void Add(string word)
    {
        Node node = root;
        for (int i = 0; i < word.Length; i++)
        {
            int index = Index(word[i]);
            if (node.Children[index] == null)
                node.Children[index] = new Node();
            node = node.Children[index]!;
        }
        node.Word = true;
    }
    public bool Contains(string word)
    {
        Node? node = root;
        for (int i = 0; i < word.Length; i++)
        {
            node = node.Children[Index(word[i])];
            if (node == null)
                return false;
        }
        return node.Word; // Узел префикса сам по себе ещё не слово. O(L).
    }
}
