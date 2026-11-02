namespace AlgoTraining.Topics.S13T05;

[Lesson("13-reference/05-learning-resources", "Ресурсы для обучения и практики")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(3, Canonical.Missing(5, [2, 5, 1, 4]), "Пропущенный номер партии");
        Check.Equal(2, Modern.Missing(4, [1, 3, 4]), "Отсутствующее событие журнала");
        Check.Equal(1, Modern.Missing(1, []), "Один ожидаемый объект");
        Check.Throws<ArgumentException>(() => Modern.Missing(3, [1, 1]), "Проверка предпосылок упражнения");
    }
}
