namespace AlgoTraining.Topics.S03T02;

[Lesson("03-algorithmic-patterns/02-fast-and-slow-pointers", "Быстрый и медленный указатели")]
public static class Applications
{
    public static void Run()
    {
        Node a = new Node(1);
        Node b = new Node(2);
        Node c = new Node(3);
        a.Next = b;
        b.Next = c;
        c.Next = b;
        Check.Equal(b, Canonical.CycleEntry(a), "Цикл перенаправлений");
        Check.Equal(b, Modern.CycleEntry(a), "Проверка через множество");
        c.Next = null;
        Check.Equal(b, Canonical.Middle(a), "Середина плейлиста");
        Check.Equal<Node?>(null, Modern.CycleEntry(a), "Линейная цепочка");
    }
}
