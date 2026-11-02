namespace AlgoTraining.Topics.S04T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Явный стек обходится без глубокой рекурсии. Память в худшем O(n).
    public static long CountFiles(Folder root)
    {
        Stack<Folder> pending = new([root]);
        long total = 0;
        while (pending.TryPop(out var folder))
        {
            total += folder.Files;
            foreach (var child in folder.Children)
                pending.Push(child);
        }
        return total;
    }
}
