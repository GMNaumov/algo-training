namespace AlgoTraining.Topics.S09T03;

[Lesson("09-bit-manipulation-and-math/03-modular-arithmetic", "Модульная арифметика")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(2L, Canonical.Power(2, 10, 7), "Количество вариантов по модулю");
        Check.Equal(new BigInteger(1), Modern.Power(10, 100, 3), "Степень большого счётчика");
        Check.Equal(5L, Canonical.Inverse(3, 7), "Обратный множитель");
        Check.Equal(3L, Canonical.Inverse(2, 5), "Модульное деление");
        Check.Throws<ArgumentException>(() => Canonical.Inverse(3, 6), "Не взаимно простые числа");
    }
}
