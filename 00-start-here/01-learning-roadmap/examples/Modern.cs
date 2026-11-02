namespace AlgoTraining.Topics.S00T01;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // LINQ сокращает запись, но всё равно просматривает весь вход: O(n).
    public static int Maximum(IEnumerable<int> values) => values.Max();
}
