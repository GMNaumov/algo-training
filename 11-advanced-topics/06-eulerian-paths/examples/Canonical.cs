namespace AlgoTraining.Topics.S11T06;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    private readonly struct Step
    {
        public readonly int To; public readonly int Id;
        public Step(int to, int id)
        {
            To = to;
            Id = id;
        }
    }
    public static int[] Undirected(int vertices, int[,] edges)
    {
        if (vertices <= 0 || edges.GetLength(1) != 2)
            throw new ArgumentException("Неверный граф.");
        List<Step>[] graph = new List<Step>[vertices];
        for (int v = 0; v < vertices; v++)
            graph[v] = new List<Step>();
        int count = edges.GetLength(0);
        for (int i = 0; i < count; i++)
        {
            int a = edges[i, 0];
            int b = edges[i, 1];
            if (a < 0 || b < 0 || a >= vertices || b >= vertices)
                throw new ArgumentException("Неизвестная вершина.");
            graph[a].Add(new Step(b, i));
            graph[b].Add(new Step(a, i));
        }
        int start = 0;
        int odd = 0;
        for (int v = 0; v < vertices; v++)
            if (graph[v].Count > 0)
                start = v;
        for (int v = 0; v < vertices; v++)
            if (graph[v].Count % 2 != 0)
            {
                odd++;
                start = v;
            }
        if (odd != 0 && odd != 2)
            throw new ArgumentException("Не 0 и не 2 нечётных вершины.");
        int[] position = new int[vertices];
        bool[] used = new bool[count];
        Stack<int> stack = new Stack<int>();
        List<int> result = new List<int>();
        stack.Push(start);
        while (stack.Count > 0)
        {
            int v = stack.Peek();
            while (position[v] < graph[v].Count && used[graph[v][position[v]].Id])
                position[v]++;
            if (position[v] == graph[v].Count)
                result.Add(stack.Pop());
            else
            {
                Step step = graph[v][position[v]++];
                used[step.Id] = true;
                stack.Push(step.To);
            }
        }
        if (result.Count != count + 1)
            throw new ArgumentException("Компоненты с рёбрами раздельны.");
        result.Reverse();
        return result.ToArray(); // O(V+E), O(V+E). Параллельные рёбра имеют разные Id.
    }
}
