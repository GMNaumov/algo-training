namespace AlgoTraining.Topics.S04T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Folder
{
    public int Files;
    public Folder[] Children;
    public Folder(int files, params Folder[] children)
    {
        Files = files;
        Children = children;
    }
}
public static class Canonical
{
    // Модель дерева: общих детей и циклов нет. O(n), стек O(h).
    public static long CountFiles(Folder folder)
    {
        long total = folder.Files;
        for (int i = 0; i < folder.Children.Length; i++)
            total += CountFiles(folder.Children[i]);
        return total;
    }
}
