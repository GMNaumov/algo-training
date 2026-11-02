namespace AlgoTraining.Topics.S07T07;

[Lesson("07-dynamic-programming/07-tree-dp", "Динамическое программирование на деревьях")]
public static class Applications
{
    public static void Run()
    {
        Node team = new Node(5, new Node(4), new Node(3));
        Check.Equal(7L, Canonical.Best(team), "Выбор дежурных без пары начальник–подчинённый");
        Node chain = new Node(5, new Node(1, new Node(6)));
        var answer = Modern.Solve(chain);
        Check.Equal(11L, Math.Max(answer.Take, answer.Skip), "Выбор точек иерархической сети");
        Check.Equal(3, Modern.SubtreeSize(team), "Число сотрудников подразделения");
        Check.Equal(1, Modern.SubtreeSize(new Node(0)), "Одиночный каталог");
    }
}
