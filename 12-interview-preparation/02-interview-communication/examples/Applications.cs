namespace AlgoTraining.Topics.S12T02;

[Lesson("12-interview-preparation/02-interview-communication", "Коммуникация на алгоритмическом собеседовании")]
public static class Applications
{
    public static void Run()
    {
        string[] explanation = Canonical.ExplainMaximum([3, 8, 2]);
        Check.Equal("Просмотрено: 3; максимум: 8", explanation[^1], "Объяснение крупнейшего чека");
        var weather = Modern.ExplainMaximum([-7, -2, -5]);
        Check.Equal(-2, weather.Answer, "Объяснение температуры");
        Check.Equal("O(1)", weather.Space, "Отдельная оценка памяти");
    }
}
