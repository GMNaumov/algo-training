namespace AlgoTraining.Topics.S03T01;

[Lesson("03-algorithmic-patterns/01-two-pointers", "Два указателя")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 2, 3 }, Canonical.FindPair([10, 20, 35, 50, 70], 85), "Две покупки");
        Check.Equal<(int, int)?>((0, 3), Modern.FindPair([1, 3, 7, 9], 10), "Два груза");
        Check.Equal<(int, int)?>(null, Modern.FindPair([5], 10), "Разные позиции обязательны");
    }
}
