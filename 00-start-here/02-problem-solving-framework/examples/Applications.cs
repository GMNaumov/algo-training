namespace AlgoTraining.Topics.S00T02;

[Lesson("00-start-here/02-problem-solving-framework", "Методика решения задач")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(true, Canonical.HasPair([40, 60, 30], 100), "Два товара на бюджет");
        Check.Equal(true, Modern.HasPair([25, 75, 10], 100), "Два платежа");
        Check.Equal(false, Modern.HasPair([50], 100), "Один товар не используется дважды");
        Check.Equal(true, Modern.HasPair([50, 50], 100), "Два разных товара одной цены");
    }
}
