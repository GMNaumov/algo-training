namespace AlgoTraining.Topics.S05T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public sealed class Modern
{
    private sealed class Node
    {
        public Dictionary<char, Node> Children { get; } = []; public bool Word;
    }
    private readonly Node root = new();
    public void Add(string word)
    {
        var node = root;
        foreach (var symbol in word)
        {
            if (!node.Children.TryGetValue(symbol, out var next))
                node.Children[symbol] = next = new();
            node = next;
        }
        node.Word = true;
    }
    public string[] Complete(string prefix)
    {
        var node = root;
        foreach (var symbol in prefix)
        {
            if (!node.Children.TryGetValue(symbol, out var next))
                return [];
            node = next;
        }
        List<string> result = [];
        Walk(node, prefix);
        return [.. result];
        void Walk(Node current, string text)
        {
            if (current.Word)
                result.Add(text);
            foreach (var (symbol, child) in current.Children.OrderBy(pair => pair.Key))
                Walk(child, text + symbol);
        }
        // Поиск префикса O(L) ожидаемо; выдача зависит от поддерева и длины вывода.
        // Конкатенация строк здесь выбрана для ясности, для большого вывода нужен буфер пути.
    }
}
