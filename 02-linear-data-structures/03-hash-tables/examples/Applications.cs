namespace AlgoTraining.Topics.S02T03;

[Lesson("02-linear-data-structures/03-hash-tables", "Хеш-таблицы")]
public static class Applications
{
    public static void Run()
    {
        Canonical ids = new Canonical(7);
        ids.Add(1);
        ids.Add(8); // Оба первоначально попадают в ячейку 1.
        Check.Equal(true, ids.Contains(8), "Поиск заказа после коллизии");
        Check.Equal(false, ids.Add(1), "Повтор идентификатора");
        Check.Equal(3, Modern.Frequencies([7, 4, 7, 9, 7])[7], "Частота артикула");
    }
}
