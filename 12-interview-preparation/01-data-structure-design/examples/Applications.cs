namespace AlgoTraining.Topics.S12T01;

[Lesson("12-interview-preparation/01-data-structure-design", "Проектирование структур данных")]
public static class Applications
{
    public static void Run()
    {
        Canonical pages = new Canonical(2);
        pages.Put(1, 10);
        pages.Put(2, 20);
        pages.TryGet(1, out _);
        pages.Put(3, 30);
        Check.Equal(false, pages.TryGet(2, out _), "Вытеснение давней страницы");
        Modern results = new(1);
        results.Put(7, 70);
        results.Put(8, 80);
        Check.Equal(false, results.TryGet(7, out _), "Кэш результатов запросов");
        Check.Equal(true, results.TryGet(8, out var value), "Попадание в кэш");
        Check.Equal(80, value, "Значение кэша");
        MinStack history = new MinStack();
        history.Push(4);
        history.Push(2);
        history.Push(2);
        history.Pop();
        Check.Equal(2, history.Minimum, "Минимум истории с повторами");
        history.Pop();
        Check.Equal(4, history.Minimum, "Минимум после отмены");
    }
}
