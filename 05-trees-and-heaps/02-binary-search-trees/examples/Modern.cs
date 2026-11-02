namespace AlgoTraining.Topics.S05T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Стандартное сбалансированное дерево даёт O(log n), в отличие от простого BST.
    public static int? FirstAtLeast(IEnumerable<int> keys, int minimum)
    {
        SortedSet<int> tree = new(keys);
        var view = tree.GetViewBetween(minimum, int.MaxValue);
        return view.Count == 0 ? null : view.Min;
    }
}
