namespace AlgoTraining.Topics.S09T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int CountBits(uint mask)
    {
        int count = 0;
        while (mask != 0)
        {
            mask = mask & (mask - 1);
            count++;
        }
        return count; // O(число единиц), O(1) при фиксированной ширине.
    }
    public static int Single(int[] ids)
    {
        int answer = 0;
        for (int i = 0; i < ids.Length; i++)
            answer = answer ^ ids[i];
        return answer; // Корректно, если все остальные номера встречаются ровно дважды.
    }
    public static uint AddFlag(uint mask, int bit)
    {
        if (bit < 0 || bit >= 32)
            throw new ArgumentOutOfRangeException(nameof(bit));
        return mask | (1u << bit);
    }
}
