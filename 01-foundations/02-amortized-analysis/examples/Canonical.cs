namespace AlgoTraining.Topics.S01T02;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private int[] items = new int[1];
    public int Count
    {
        get; private set;
    }
    public int Copies
    {
        get; private set;
    }
    public void Add(int value)
    {
        if (Count == items.Length)
        {
            int[] larger = new int[checked(items.Length * 2)];
            for (int i = 0; i < Count; i++)
            {
                larger[i] = items[i];
                Copies++;
            }
            items = larger;
        }
        items[Count] = value;
        Count++;
    }
    // Добавление амортизированно O(1), расширение O(n), хранение O(n).
    public int Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        return items[index];
    }
}
