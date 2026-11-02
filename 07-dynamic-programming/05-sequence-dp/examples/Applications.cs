namespace AlgoTraining.Topics.S07T05;

[Lesson("07-dynamic-programming/05-sequence-dp", "Динамическое программирование на последовательностях")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(2, Canonical.Lcs("ABC", "AC"), "Общие действия пользователей");
        Check.Equal(1, Modern.Lcs("AB", "BA"), "Сравнение версий последовательности");
        Check.Equal(1, Canonical.EditDistance("кот", "кит"), "Исправление опечатки");
        Check.Equal(3, Canonical.EditDistance("", "abc"), "Вставка нового текста");
        Check.Equal(3, Canonical.Lis([3, 1, 2, 5]), "Растущий тренд измерений");
        Check.Equal(1, Modern.Lis([2, 2, 2]), "Равные цены не образуют строгий рост");
    }
}
