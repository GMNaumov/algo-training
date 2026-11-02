namespace AlgoTraining.Topics.S06T04;

[Lesson("06-graphs/04-topological-sort", "Топологическая сортировка")]
public static class Applications
{
    public static void Run()
    {
        int[][] build = [new[] { 1 }, new[] { 2, 3 }, new[] { 3 }, Array.Empty<int>()];
        Check.Sequence(new[] { 0, 1, 2, 3 }, Canonical.Sort(build), "Порядок подготовки отчёта");
        Check.Sequence(new[] { 0, 1, 2 }, Modern.Sort([new[] { 2 }, new[] { 2 }, Array.Empty<int>()]), "Предсказуемый план сборки");
        Check.Throws<ArgumentException>(() => Canonical.Sort([new[] { 1 }, new[] { 0 }]), "Цикл");
    }
}
