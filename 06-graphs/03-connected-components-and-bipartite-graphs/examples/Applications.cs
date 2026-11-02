namespace AlgoTraining.Topics.S06T03;

[Lesson("06-graphs/03-connected-components-and-bipartite-graphs", "Компоненты связности и двудольные графы")]
public static class Applications
{
    public static void Run()
    {
        Check.Sequence(new[] { 0, 0, 1, 1, 2 }, Canonical.Components([new[] { 1 }, new[] { 0 }, new[] { 3 }, new[] { 2 }, Array.Empty<int>()]), "Отдельные сети офисов");
        Check.Equal(true, Modern.IsBipartite([new[] { 1, 3 }, new[] { 0, 2 }, new[] { 1, 3 }, new[] { 0, 2 }]), "Две смены без конфликта");
        Check.Equal(false, Modern.IsBipartite([new[] { 1, 2 }, new[] { 0, 2 }, new[] { 0, 1 }]), "Нечётный цикл");
    }
}
