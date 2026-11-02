namespace AlgoTraining.Topics.S07T01;

[Lesson("07-dynamic-programming/01-dp-foundations", "Основы динамического программирования")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(5L, Canonical.Stairs(4), "Маршруты по лестнице");
        Check.Equal(8L, Canonical.Memoized(5), "Мемоизация тех же маршрутов");
        Check.Equal(new BigInteger(8), Modern.Stairs(5), "Комбинации шагов интерфейса");
        Check.Equal(BigInteger.One, Modern.Stairs(0), "Пустая последовательность");
    }
}
