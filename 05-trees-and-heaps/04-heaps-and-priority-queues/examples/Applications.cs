namespace AlgoTraining.Topics.S05T04;

[Lesson("05-trees-and-heaps/04-heaps-and-priority-queues", "Кучи и приоритетные очереди")]
public static class Applications
{
    public static void Run()
    {
        Canonical reminders = new Canonical();
        reminders.Add(5);
        reminders.Add(2);
        reminders.Add(3);
        reminders.Add(1);
        Check.Sequence(new[] { 1, 2, 3, 5 }, Enumerable.Range(0, 4).Select(_ => reminders.Pop()), "Ближайшие напоминания");
        Check.Sequence(new[] { "Б", "В", "А" }, Modern.Schedule([("А", 5), ("Б", 1), ("В", 1)]), "Диспетчер событий");
        Check.Throws<InvalidOperationException>(() => reminders.Pop(), "Извлечение из пустой кучи");
    }
}
