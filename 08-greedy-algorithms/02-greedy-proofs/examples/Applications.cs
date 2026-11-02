namespace AlgoTraining.Topics.S08T02;

[Lesson("08-greedy-algorithms/02-greedy-proofs", "Доказательство корректности жадных алгоритмов")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(11L, Canonical.CompletionSum([4, 2, 1]), "Очередь одинаково важных работ");
        Check.Equal(5L, Modern.CompletionSum([3, 1]), "Сумма ожидания печати");
        Check.Equal(true, Canonical.PairContribution(1, 3) <= Canonical.PairContribution(3, 1), "Обмен не ухудшает ответ");
        Check.Equal(0L, Modern.CompletionSum([]), "Нет работ");
    }
}
