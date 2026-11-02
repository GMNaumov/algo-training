namespace AlgoTraining.Topics.S02T03;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    // Стандартная библиотека сама обрабатывает коллизии и рост таблицы.
    public static Dictionary<int, int> Frequencies(IEnumerable<int> products) =>
        products.GroupBy(product => product).ToDictionary(group => group.Key, group => group.Count());
}
