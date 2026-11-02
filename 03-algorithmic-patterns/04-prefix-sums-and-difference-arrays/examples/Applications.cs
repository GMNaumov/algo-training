namespace AlgoTraining.Topics.S03T04;

[Lesson("03-algorithmic-patterns/04-prefix-sums-and-difference-arrays", "Префиксные суммы и разностные массивы")]
public static class Applications
{
    public static void Run()
    {
        long[] prefix = Canonical.Prefix([3, 5, 2, 6]);
        Check.Equal(7L, prefix[3] - prefix[1], "Продажи второго и третьего дня");
        Check.Equal(8L, new Modern([3, 5, 2, 6]).Sum(2..^0), "Продажи последних дней");
        Check.Sequence(new long[] { 0, 10, 15, 5 }, Canonical.AddRanges(4, new int[,] { { 1, 3, 10 }, { 2, 4, 5 } }), "Надбавки по датам");
    }
}
