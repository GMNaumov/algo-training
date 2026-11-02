namespace AlgoTraining.Topics.S05T01;

[Lesson("05-trees-and-heaps/01-binary-trees-and-traversals", "Бинарные деревья и их обходы")]
public static class Applications
{
    public static void Run()
    {
        Node root = new Node("А", new Node("Б", new Node("Г"), new Node("Д")), new Node("В"));
        List<string> pre = new();
        Canonical.Traverse(root, pre, "pre");
        Check.Sequence(new[] { "А", "Б", "Г", "Д", "В" }, pre, "Иерархия категорий");
        List<string> post = new();
        Canonical.Traverse(root, post, "post");
        Check.Sequence(new[] { "Г", "Д", "Б", "В", "А" }, post, "Обработка детей до родителя");
        Check.Sequence(new[] { "Г", "Б", "Д", "А", "В" }, Modern.InOrder(root), "Симметричный обход");
        Check.Sequence(new[] { "А", "Б", "В", "Г", "Д" }, Canonical.BreadthFirst(root), "Уровни организации");
    }
}
