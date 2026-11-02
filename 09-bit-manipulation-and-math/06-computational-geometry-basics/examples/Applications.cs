namespace AlgoTraining.Topics.S09T06;

[Lesson("09-bit-manipulation-and-math/06-computational-geometry-basics", "Основы вычислительной геометрии")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(new BigInteger(12), Canonical.Cross(0, 0, 4, 0, 2, 3), "Склад слева от дороги");
        Check.Equal(false, Canonical.OnSegment(0, 0, 2, 2, 3, 3), "Точка за концом дороги");
        Check.Equal(true, Modern.Intersects(new(0, 0), new(2, 2), new(0, 2), new(2, 0)), "Пересечение маршрутов");
        Check.Equal(false, Modern.Intersects(new(0, 0), new(1, 0), new(2, 0), new(3, 0)), "Раздельные участки");
        Check.Equal(new BigInteger(25), Modern.DistanceSquared(new(0, 0), new(3, 4)), "Сравнение расстояний");
    }
}
