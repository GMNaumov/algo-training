namespace AlgoTraining.Topics.S12T04;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public readonly record struct Review(bool Clarified, bool Proved, bool Tested, bool Estimated)
{
    public int Completed => new[] { Clarified, Proved, Tested, Estimated }.Count(done => done);
}
public static class Modern
{
    public static bool Passes(Func<string, bool> candidate, IEnumerable<(string Input, bool Expected)> cases) =>
        cases.All(test => candidate(test.Input) == test.Expected);
    // Проверки ответа не оценивают речь и доказательство: это отдельные пункты Review.
}
