namespace AlgoTraining.Topics.S09T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static BigInteger Power(BigInteger value, BigInteger exponent, BigInteger modulus)
    {
        if (exponent < 0 || modulus <= 0)
            throw new ArgumentException("Неверные параметры.");
        return BigInteger.ModPow((value % modulus + modulus) % modulus, exponent, modulus);
    }
}
