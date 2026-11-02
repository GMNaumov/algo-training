namespace AlgoTraining.Topics.S09T01;

[Lesson("09-bit-manipulation-and-math/01-bit-manipulation", "Битовые операции")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(2, Canonical.CountBits(0b1100), "Число разрешённых функций");
        Check.Equal(3u, Canonical.AddFlag(0b0001, 1), "Добавление разрешения");
        Check.Equal(3, Canonical.Single([6, 3, 6]), "Одиночный номер");
        Check.Equal(9, Modern.Single([2, 9, 2]), "Непарный идентификатор события");
        Check.Equal(2, Modern.CountBits(0b1010), "Число выбранных задач");
        Check.Equal(false, Modern.IsPowerOfTwo(0), "Ноль не степень двойки");
    }
}
