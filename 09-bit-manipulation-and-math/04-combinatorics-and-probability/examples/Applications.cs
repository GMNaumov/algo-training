namespace AlgoTraining.Topics.S09T04;

[Lesson("09-bit-manipulation-and-math/04-combinatorics-and-probability", "Комбинаторика и вероятность")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(new BigInteger(10), Canonical.Choose(5, 2), "Выбор команды");
        Check.Equal(new BigInteger(15), Modern.Choose(6, 2), "Пары дежурных");
        Check.Equal(0.5, Canonical.ExactlyOneHead(), "Точный перебор исходов двух монет");
        Check.Equal(1.5, Modern.ExpectedHeads(3), "Среднее число орлов");
        Check.Equal(BigInteger.One, Modern.Choose(0, 0), "Пустой выбор");
    }
}
