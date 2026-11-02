namespace AlgoTraining.Topics.S04T02;

[Lesson("04-recursion-sorting-searching/02-divide-and-conquer", "Разделяй и властвуй")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 2, 3, 6, 8 }, Canonical.Sort([8, 3, 6, 2]), "Сортировка счетов");
        Check.Sequence(new[] { -1, 2, 2, 9 }, Modern.Sort([2, 9, -1, 2]), "Упорядочивание измерений");
        Check.Sequence(Array.Empty<int>(), Modern.Sort([]), "Пустой вход");
    }
}
