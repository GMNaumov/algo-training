global using AlgoTraining;
global using System.Numerics;
global using System.Diagnostics;
global using System.Text;

namespace AlgoTraining;

public readonly record struct WeightedEdge(int From, int To, int Weight);

public static class GraphInput
{
    public static void Validate(int vertices, IEnumerable<WeightedEdge> edges, int start = 0)
    {
        if (vertices <= 0 || start < 0 || start >= vertices)
            throw new ArgumentOutOfRangeException(nameof(vertices));
        foreach (var edge in edges)
            if (edge.From < 0 || edge.To < 0 || edge.From >= vertices || edge.To >= vertices)
                throw new ArgumentException("Номер вершины вне графа.");
    }
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class LessonAttribute(string id, string title) : Attribute
{
    public string Id { get; } = id;
    public string Title { get; } = title;
}

// Проверки выполняются и в Release: в отличие от Debug.Assert они не исчезают.
public static class Check
{
    public static int Count
    {
        get; private set;
    }
    internal static bool Quiet
    {
        get; set;
    }

    public static void Equal<T>(T expected, T actual, string scenario)
    {
        Count++;
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new InvalidOperationException($"{scenario}: ожидалось {expected}, получено {actual}");
        if (!Quiet)
            Console.WriteLine($"  {scenario}: {actual}");
    }

    public static void Sequence<T>(IEnumerable<T> expected, IEnumerable<T> actual, string scenario)
    {
        T[] result = actual.ToArray();
        Count++;
        if (!expected.SequenceEqual(result))
            throw new InvalidOperationException($"{scenario}: получено [{string.Join(", ", result)}]");
        if (!Quiet)
            Console.WriteLine($"  {scenario}: [{string.Join(", ", result)}]");
    }

    public static void Throws<TException>(Action action, string scenario) where TException : Exception
    {
        Count++;
        try
        {
            action();
        }
        catch (TException) { if (!Quiet) Console.WriteLine($"  {scenario}: {typeof(TException).Name}"); return; }
        throw new InvalidOperationException($"{scenario}: ожидалось исключение {typeof(TException).Name}");
    }
}
