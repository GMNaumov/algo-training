namespace AlgoTraining.Topics.S01T05;

[Lesson("01-foundations/05-dotnet-collections", "Коллекции .NET")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(2, Canonical.Frequencies(["Анна", "Борис", "Анна"])["Анна"], "Заказы клиента");
        Check.Equal(1, Modern.Frequencies(["Борис"])["Борис"], "Группировка клиентов");
        Check.Equal("Срочная", Modern.NextUrgent(), "Приоритет доставки");
        Stack<string> undo = new();
        undo.Push("А");
        undo.Push("Б");
        Queue<string> print = new();
        print.Enqueue("А");
        print.Enqueue("Б");
        Check.Equal("Б", undo.Pop(), "Отмена");
        Check.Equal("А", print.Dequeue(), "Печать");
        Check.Equal(2, new HashSet<int> { 1, 1, 2 }.Count, "Уникальные артикулы");
        Check.Sequence(new[] { 1, 2, 3 }, new SortedSet<int> { 3, 1, 2 }, "Упорядоченный каталог");
        SortedDictionary<int, string> catalog = new()
        {
            [2] = "Б",
            [1] = "А"
        };
        Check.Sequence(new[] { 1, 2 }, catalog.Keys, "Ключи по порядку");
        LinkedList<string> playlist = new();
        playlist.AddLast("А");
        playlist.AddFirst("Б");
        Check.Equal("Б", playlist.First!.Value, "Изменение плейлиста");
    }
}
