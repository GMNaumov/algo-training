namespace AlgoTraining.Topics.S12T05;

[Lesson("12-interview-preparation/05-company-specific-preparation", "Подготовка к собеседованиям в конкретные компании")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal("Графы", Canonical.NextTopic(["Массивы", "Графы"], [5, 5], [4, 1]), "Приоритет по пробелам");
        var plan = Modern.Plan([new("ДП", 5, 2, "условная вакансия"), new("Массивы", 4, 4, "пробная сессия")]);
        Check.Equal("ДП", plan[0].Topic, "План повторения перед отбором");
        Check.Equal("условная вакансия", plan[0].Source, "Основание сохранено");
    }
}
