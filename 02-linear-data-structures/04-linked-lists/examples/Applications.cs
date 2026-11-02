namespace AlgoTraining.Topics.S02T04;

[Lesson("02-linear-data-structures/04-linked-lists", "Связные списки")]
public static class Applications
{
    public static void Run()
    {
        Node playlist = new Node(1, new Node(3));
        Canonical.InsertAfter(playlist, 2);
        Check.Sequence(new[] { 1, 2, 3 }, Modern.Values(playlist), "Вставка трека");
        Node? reversed = Canonical.Reverse(playlist);
        Check.Sequence(new[] { 3, 2, 1 }, Modern.Values(reversed), "Обратный маршрут");
        Check.Sequence(new[] { 1, 2, 3 }, Modern.Values(Modern.Reverse(reversed)), "Восстановление порядка");
        Check.Equal<Node?>(null, Modern.Reverse(null), "Пустой список");
    }
}
