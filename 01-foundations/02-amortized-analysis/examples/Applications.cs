namespace AlgoTraining.Topics.S01T02;

[Lesson("01-foundations/02-amortized-analysis", "Амортизированный анализ")]
public static class Applications
{
    public static void Run()
    {
        Canonical cart = new Canonical();
        for (int i = 1; i <= 9; i++)
            cart.Add(i);
        Check.Equal(15, cart.Copies, "Переносы при росте корзины 1–2–4–8–16");
        Check.Equal(9, cart.Get(8), "Девятая покупка");
        Check.Sequence(new[] { 10, 20, 30 }, Modern.Collect([10, 20, 30]), "Сбор событий в List");
    }
}
