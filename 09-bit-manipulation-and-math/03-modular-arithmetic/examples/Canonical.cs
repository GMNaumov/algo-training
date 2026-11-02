namespace AlgoTraining.Topics.S09T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static long Power(long value, long exponent, int modulus)
    {
        if (exponent < 0 || modulus <= 0)
            throw new ArgumentOutOfRangeException(nameof(exponent));
        value = (value % modulus + modulus) % modulus;
        long result = 1 % modulus;
        while (exponent > 0)
        {
            // После сокращения оба множителя < int.MaxValue, произведение помещается в long.
            if ((exponent & 1) != 0)
                result = result * value % modulus;
            value = value * value % modulus;
            exponent /= 2;
        }
        return result; // O(log exponent), O(1) машинных чисел.
    }
    public static long Inverse(int value, int modulus)
    {
        if (modulus <= 1)
            throw new ArgumentOutOfRangeException(nameof(modulus));
        long a = ((long)value % modulus + modulus) % modulus;
        long b = modulus;
        long x = 1;
        long y = 0;
        while (b != 0)
        {
            long q = a / b;
            long remainder = a % b;
            a = b;
            b = remainder;
            long next = x - q * y;
            x = y;
            y = next;
        }
        if (a != 1)
            throw new ArgumentException("Обратного элемента нет.");
        return (x % modulus + modulus) % modulus;
    }
}
