namespace AlgoTraining.Topics.S13T02;

[Lesson("13-reference/02-csharp-cheatsheet", "Шпаргалка по C# и коллекциям .NET")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(3_000_000_000L, Canonical.Sum([1_500_000_000, 1_500_000_000]), "Широкая сумма");
        int[] source = [3, 1, 2];
        int[] copy = Canonical.Copy(source);
        copy[0] = 99;
        Check.Equal(3, source[0], "Копия не меняет исходник");
        Check.Equal(6L, source.CheckedTotal(), "Метод расширения C# 14");
        Check.Sequence(new[] { 1, 2, 3 }, Modern.SortedCopy(source), "Сортировка снимка");
    }
}
