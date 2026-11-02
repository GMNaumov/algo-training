namespace AlgoTraining.Topics.S05T05;

[Lesson("05-trees-and-heaps/05-tries", "Префиксные деревья")]
public static class Applications
{
    public static void Run()
    {
        Canonical commands = new Canonical();
        commands.Add("get");
        commands.Add("getter");
        Check.Equal(true, commands.Contains("get"), "Словарь команд");
        Check.Equal(false, commands.Contains("ge"), "Префикс не равен слову");
        Modern search = new();
        search.Add("кот");
        search.Add("код");
        search.Add("дом");
        Check.Sequence(new[] { "код", "кот" }, search.Complete("ко"), "Автодополнение");
    }
}
