namespace AlgoTraining.Topics.S00T01;

[Lesson("00-start-here/01-learning-roadmap", "Дорожная карта обучения")]
public static class Applications
{
    public static void Run()
    {
        // Практика 1: крупнейший чек. Практика 2: самый тёплый день.
        Check.Equal(200, Canonical.Maximum(new int[] { 120, 70, 200 }), "Крупнейший чек");
        Check.Equal(-2, Modern.Maximum([-8, -2, -5]), "Температура ниже нуля");
        Check.Throws<ArgumentException>(() => Canonical.Maximum([]), "Пустой вход");
    }
}
