namespace AlgoTraining.Topics.S12T04;

[Lesson("12-interview-preparation/04-mock-interviews", "Пробные собеседования")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(true, Canonical.IsSortedPermutation([3, 1, 1], [1, 1, 3]), "Проверка решения о чеках");
        Check.Equal(false, Canonical.IsSortedPermutation([3, 1, 1], [1, 2, 3]), "Порядок верен, состав испорчен");
        Check.Equal(true, Modern.Passes(S02T05.Canonical.Balanced, [("([])", true), ("([)]", false), ("", true)]), "Репетиция по скобкам");
        Check.Equal(3, new Review(true, false, true, true).Completed, "Конкретная обратная связь");
    }
}
