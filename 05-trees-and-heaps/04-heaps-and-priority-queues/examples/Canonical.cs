namespace AlgoTraining.Topics.S05T04;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly List<int> values = new List<int>();
    public int Count
    {
        get
        {
            return values.Count;
        }
    }
    public void Add(int value)
    {
        values.Add(value);
        int index = values.Count - 1;
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (values[parent] <= values[index])
                break;
            Swap(parent, index);
            index = parent;
        }
    }
    public int Pop()
    {
        if (values.Count == 0)
            throw new InvalidOperationException("Куча пуста.");
        int minimum = values[0];
        values[0] = values[values.Count - 1];
        values.RemoveAt(values.Count - 1);
        int index = 0;
        while (index < values.Count / 2)
        {
            int child = index * 2 + 1;
            if (child + 1 < values.Count && values[child + 1] < values[child])
                child++;
            if (values[index] <= values[child])
                break;
            Swap(index, child);
            index = child;
        }
        return minimum;
    }
    private void Swap(int i, int j)
    {
        int temporary = values[i];
        values[i] = values[j];
        values[j] = temporary;
    }
    // Add/Pop O(log n), память O(n). Порядок всего массива не является сортировкой.
}
