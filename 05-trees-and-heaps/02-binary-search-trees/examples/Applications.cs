namespace AlgoTraining.Topics.S05T02;

[Lesson("05-trees-and-heaps/02-binary-search-trees", "Бинарные деревья поиска")]
public static class Applications
{
    public static void Run()
    {
        Canonical catalog = new Canonical();
        foreach (int key in new[] { 40, 20, 60, 10, 30 })
            catalog.Add(key);
        Check.Equal(true, catalog.Contains(30), "Поиск артикула");
        catalog.Remove(40);
        Check.Equal(false, catalog.Contains(40), "Удаление узла с двумя детьми");
        Check.Equal(true, catalog.Contains(60), "Сохранённый преемник");
        Check.Equal<int?>(30, Modern.FirstAtLeast([10, 20, 30, 60], 25), "Ближайшая доступная цена");
    }
}
