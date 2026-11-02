namespace AlgoTraining.Topics.S09T06;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public readonly record struct Point(int X, int Y);
public static class Modern
{
    public static BigInteger Cross(Point a, Point b, Point c) => Canonical.Cross(a.X, a.Y, b.X, b.Y, c.X, c.Y);
    public static bool Intersects(Point a, Point b, Point c, Point d)
    {
        var x = Cross(a, b, c);
        var y = Cross(a, b, d);
        var z = Cross(c, d, a);
        var w = Cross(c, d, b);
        if (x.IsZero && On(a, b, c) || y.IsZero && On(a, b, d) || z.IsZero && On(c, d, a) || w.IsZero && On(c, d, b))
            return true;
        return x.Sign * y.Sign < 0 && z.Sign * w.Sign < 0;
    }
    private static bool On(Point a, Point b, Point p) => Canonical.OnSegment(a.X, a.Y, b.X, b.Y, p.X, p.Y);
    public static BigInteger DistanceSquared(Point a, Point b) => BigInteger.Pow((BigInteger)a.X - b.X, 2) + BigInteger.Pow((BigInteger)a.Y - b.Y, 2);
    // Постоянное число арифметических операций; цена BigInteger зависит от разрядности.
}
