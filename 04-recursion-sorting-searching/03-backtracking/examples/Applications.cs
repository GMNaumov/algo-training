namespace AlgoTraining.Topics.S04T03;

[Lesson("04-recursion-sorting-searching/03-backtracking", "Поиск с возвратом")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(1, Canonical.SubsetsWithSum([2, 4, 5], 7).Count, "Набор покупок на 7");
        Check.Equal(2, Modern.SubsetsWithSum([1, 2, 3], 3).Count(), "Комбинации оборудования");
        Check.Equal(1, Canonical.SubsetsWithSum([], 0).Count, "Пустой набор для нулевой цели");
    }
}
