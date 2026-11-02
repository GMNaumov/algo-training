namespace AlgoTraining.Topics.S09T05;

[Lesson("09-bit-manipulation-and-math/05-randomized-algorithms", "Рандомизированные алгоритмы")]
public static class Applications
{
    public static void Run()
    {
        int[] entries = [10, 20, 30, 40];
        Check.Equal(true, entries.Contains(Canonical.Reservoir(entries, new Random(42))), "Победитель среди заявок");
        Check.Equal("единственный", Modern.Reservoir(new[] { "единственный" }, new Random(42)), "Выбор из потока");
        int[] deck = [1, 2, 3, 4];
        Canonical.Shuffle(deck, new Random(42));
        Check.Sequence(new[] { 1, 2, 3, 4 }, deck.Order(), "Перемешанная колода сохраняет состав");
        string[] questions = ["А", "Б", "В"];
        Modern.Shuffle<string>(questions, new Random(42));
        Check.Sequence(new[] { "А", "Б", "В" }, questions.Order(StringComparer.Ordinal), "Порядок вопросов");
    }
}
