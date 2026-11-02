namespace AlgoTraining.Topics.S01T02;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // List<T> предоставляет динамический массив: внутренние переносы скрыты.
    public static List<int> Collect(IEnumerable<int> source)
    {
        List<int> result = [];
        foreach (var item in source)
            result.Add(item);
        return result;
    }
}
