namespace AlgoTraining.Topics.S09T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    // BigInteger исключает переполнение даже для крайних int-координат.
    public static BigInteger Cross(int ax, int ay, int bx, int by, int cx, int cy)
    {
        return ((BigInteger)bx - ax) * ((BigInteger)cy - ay) - ((BigInteger)by - ay) * ((BigInteger)cx - ax);
    }
    public static bool OnSegment(int ax, int ay, int bx, int by, int px, int py)
    {
        return Cross(ax, ay, bx, by, px, py) == 0 && px >= Math.Min(ax, bx) && px <= Math.Max(ax, bx)
            && py >= Math.Min(ay, by) && py <= Math.Max(ay, by);
    }
}
