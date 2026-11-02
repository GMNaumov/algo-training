namespace AlgoTraining.Topics.S05T03;

[Lesson("05-trees-and-heaps/03-balanced-search-trees", "Сбалансированные деревья поиска")]
public static class Applications
{
    public static void Run()
    {
        Canonical ids = new Canonical();
        for (int i = 1; i <= 7; i++)
            ids.Add(i);
        Check.Equal(3, ids.Height, "Баланс при поступлении возрастающих номеров");
        Check.Equal(true, ids.Contains(6), "Поиск в AVL");
        Canonical zigzag = new Canonical();
        zigzag.Add(30);
        zigzag.Add(10);
        zigzag.Add(20);
        Check.Equal(2, zigzag.Height, "Двойной поворот");
        Check.Sequence(new[] { 20, 30 }, Modern.PricesWithin([40, 10, 30, 20], 15, 35), "Цены в диапазоне");
    }
}
