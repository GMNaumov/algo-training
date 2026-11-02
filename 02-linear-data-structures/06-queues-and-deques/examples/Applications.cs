namespace AlgoTraining.Topics.S02T06;

[Lesson("02-linear-data-structures/06-queues-and-deques", "Очереди и деки")]
public static class Applications
{
    public static void Run()
    {
        Canonical print = new Canonical(2);
        print.Enqueue(1);
        print.Enqueue(2);
        Check.Equal(1, print.Dequeue(), "Первый документ");
        print.Enqueue(3);
        Check.Equal(2, print.Dequeue(), "После оборота кольца");
        Check.Equal(3, print.Dequeue(), "Последний документ");
        Modern<string> tasks = new();
        tasks.AddLast("обычная");
        tasks.AddFirst("срочная");
        Check.Equal("срочная", tasks.RemoveFirst(), "Задача с начала дека");
        Check.Equal("обычная", tasks.RemoveLast(), "Задача с конца дека");
    }
}
