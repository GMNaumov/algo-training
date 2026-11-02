namespace AlgoTraining.Topics.S09T02;

[Lesson("09-bit-manipulation-and-math/02-number-theory-and-primes", "Теория чисел и простые числа")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(6L, Canonical.Gcd(48, 18), "Одинаковые подарочные наборы");
        Check.Equal(420L, Canonical.Lcm(84, 30), "Совпадение периодов");
        Check.Equal(new BigInteger(6), Modern.Gcd(84, 30), "НОД больших счётчиков");
        Check.Equal(false, Canonical.IsPrime(49), "Составной размер партии");
        Check.Sequence(new[] { 2, 3, 5, 7, 11, 13, 17, 19 }, Canonical.Sieve(20), "Таблица простых");
        Check.Sequence(new[] { 2, 3, 5, 7 }, Modern.Primes(10), "Ленивая выдача простых");
    }
}
