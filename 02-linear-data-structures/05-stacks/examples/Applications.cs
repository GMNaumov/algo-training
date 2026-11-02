namespace AlgoTraining.Topics.S02T05;

[Lesson("02-linear-data-structures/05-stacks", "Стеки")]
public static class Applications
{
    public static void Run()
    {
        Check.Equal(true, Canonical.Balanced("([])"), "Скобки формулы");
        Check.Equal(false, Modern.Balanced("([)]"), "Нарушенная вложенность");
        IntStack history = new IntStack();
        history.Push(10);
        history.Push(20);
        Check.Equal(20, history.Pop(), "Отмена последнего изменения");
        Check.Equal(true, Modern.Balanced(""), "Пустое выражение");
    }
}
