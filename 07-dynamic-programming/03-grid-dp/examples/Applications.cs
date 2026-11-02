namespace AlgoTraining.Topics.S07T03;

[Lesson("07-dynamic-programming/03-grid-dp", "Динамическое программирование на сетках")]
public static class Applications
{
    public static void Run()
    {
        bool[,] warehouse = new bool[3, 3];
        warehouse[1, 1] = true;
        Check.Equal(2L, Canonical.Paths(warehouse), "Обход препятствия на складе");
        Check.Equal(new BigInteger(3), Modern.Paths(new bool[2, 3]), "Маршруты по панели");
        Check.Equal(6L, Canonical.MinCost(new int[,] { { 1, 3, 1 }, { 1, 5, 1 } }), "Дешёвый путь доставки");
        Check.Equal(7L, Canonical.MinCost(new int[,] { { 7 } }), "Стоимость единственной клетки");
    }
}
