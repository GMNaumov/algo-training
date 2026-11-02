namespace AlgoTraining.Topics.S02T03;

// Каноничная версия: явные типы и основные шаги без LINQ.
public sealed class Canonical
{
    private readonly int[] keys;
    private readonly bool[] occupied;
    private int count;
    public Canonical(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));
        keys = new int[capacity];
        occupied = new bool[capacity];
    }
    // Линейное пробирование: коллизия означает переход к следующей ячейке.
    // Для простоты нет удаления и расширения. Ожидаемое O(1) требует малого заполнения.
    private int Slot(int key)
    {
        int slot = (int)((uint)key % (uint)keys.Length);
        for (int step = 0; step < keys.Length; step++)
        {
            if (!occupied[slot] || keys[slot] == key)
                return slot;
            slot = (slot + 1) % keys.Length;
        }
        return -1;
    }
    public bool Contains(int key)
    {
        int slot = Slot(key);
        return slot >= 0 && occupied[slot];
    }
    public bool Add(int key)
    {
        int slot = Slot(key);
        if (slot < 0)
            throw new InvalidOperationException("Учебная таблица заполнена.");
        if (occupied[slot])
            return false;
        keys[slot] = key;
        occupied[slot] = true;
        count++;
        return true;
    }
    public int Count
    {
        get
        {
            return count;
        }
    }
}
