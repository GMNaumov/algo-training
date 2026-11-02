namespace AlgoTraining.Topics;

// Проверки без NuGet-зависимостей. Небольшие входы позволяют сравнивать с перебором.
// Фиксированный seed воспроизводит ошибку; успешный прогон не заменяет доказательство.
public static class Verification
{
    public static void Run()
    {
        Check.Quiet = true;
        try
        {
            Arrays();
            Console.WriteLine("Массивы, сортировки, окна и выбор: пройдено.");
            Strings();
            Console.WriteLine("Строки, суффиксы и палиндромы: пройдено.");
            Graphs();
            Console.WriteLine("Пути, компоненты и потоки: пройдено.");
            Structures();
            Console.WriteLine("Изменяемые структуры и LCA: пройдено.");
            DynamicProgramming();
            Console.WriteLine("ДП против полного перебора: пройдено.");
            EdgeCases();
            Console.WriteLine("Границы, ленивые обновления и малые назначения: пройдено.");
        }
        finally { Check.Quiet = false; }
    }

    private static void Arrays()
    {
        Random random = new(71);
        Action<int[]>[] sorts = [S04T04.Canonical.Insertion, S04T04.Canonical.Selection, S04T04.Canonical.Merge, S04T04.Canonical.Quick, S04T04.Canonical.Heap];
        for (int test = 0; test < 80; test++)
        {
            int[] data = Enumerable.Range(0, test % 13).Select(_ => random.Next(-5, 7)).ToArray();
            int[] sorted = data.Order().ToArray();
            foreach (var sort in sorts)
            {
                int[] copy = (int[])data.Clone();
                sort(copy);
                Check.Sequence(sorted, copy, $"Сортировка {sort.Method.Name}");
            }
            int[] nonnegative = data.Select(x => x + 5).ToArray();
            S04T04.Canonical.Counting(nonnegative, 11);
            Check.Sequence(sorted.Select(x => x + 5), nonnegative, "Подсчёт");
            for (int rank = 1; rank <= data.Length; rank++)
            {
                int[] copy = (int[])data.Clone();
                Check.Equal(sorted[rank - 1], S04T07.Modern.Select(copy, rank, random), "Quickselect");
            }
            for (int size = 1; size <= data.Length; size++)
            {
                long expected = Enumerable.Range(0, data.Length - size + 1).Max(i => data.Skip(i).Take(size).Sum(x => (long)x));
                Check.Equal(expected, S03T03.Canonical.MaxSum(data, size), "Окно против перебора");
                Check.Equal(expected, S03T03.Modern.MaxSum(data, size), "Span-окно");
                int[] peaks = Enumerable.Range(0, data.Length - size + 1).Select(i => data.Skip(i).Take(size).Max()).ToArray();
                Check.Sequence(peaks, S03T06.Canonical.MaxWindows(data, size), "Монотонный буфер");
                Check.Sequence(peaks, S03T06.Modern.MaxWindows(data, size), "Монотонный дек");
            }
            int[] warmer = Enumerable.Range(0, data.Length).Select(i => Enumerable.Range(i + 1, data.Length - i - 1).Where(j => data[j] > data[i]).Select(j => j - i).FirstOrDefault()).ToArray();
            Check.Sequence(warmer, S03T06.Canonical.Warmer(data), "Следующий больший");
            for (int target = -10; target <= 12; target++)
                Check.Equal(S00T02.Canonical.HasPair(data, target), S03T01.Modern.FindPair(sorted, target).HasValue, "Два указателя");
        }
    }

    private static IEnumerable<string> BinaryStrings(int maxLength)
    {
        for (int length = 0; length <= maxLength; length++)
            for (int mask = 0; mask < 1 << length; mask++)
                yield return new string(Enumerable.Range(0, length).Select(i => (mask & (1 << i)) == 0 ? 'a' : 'b').ToArray());
    }

    private static void Strings()
    {
        foreach (string text in BinaryStrings(6))
        {
            int[] suffixes = S10T05.Canonical.SuffixArray(text);
            Check.Sequence(suffixes, S10T05.Modern.SuffixArray(text), "Удвоение суффиксов");
            int[] expectedLcp = new int[text.Length];
            for (int i = 1; i < suffixes.Length; i++)
                while (suffixes[i] + expectedLcp[i] < text.Length && suffixes[i - 1] + expectedLcp[i] < text.Length && text[suffixes[i] + expectedLcp[i]] == text[suffixes[i - 1] + expectedLcp[i]])
                    expectedLcp[i]++;
            Check.Sequence(expectedLcp, S10T05.Modern.Lcp(text, suffixes), "Касаи");
            Check.Equal(S10T06.Canonical.Longest(text), S10T06.Modern.Longest(text), "Манакер");
            S10T05.SuffixTree tree = new(text);
            S10T05.SuffixAutomaton automaton = new(text);
            foreach (string pattern in BinaryStrings(3))
            {
                int[] expected = S10T01.Canonical.Find(text, pattern);
                Check.Sequence(expected, S10T01.Modern.Find(text, pattern), "Span.IndexOf");
                Check.Sequence(expected, S10T02.Canonical.Find(text, pattern), "КМП");
                Check.Sequence(expected, S10T02.Modern.Find(text, pattern), "КМП-итератор");
                Check.Sequence(expected, S10T03.Modern.Find(text, pattern), "Z-поиск");
                Check.Sequence(expected, S10T04.Canonical.FindVerified(text, pattern), "Хеш с подтверждением");
                Check.Equal(text.Contains(pattern, StringComparison.Ordinal), tree.Contains(pattern), "Суффиксное дерево");
                Check.Equal(text.Contains(pattern, StringComparison.Ordinal), automaton.Contains(pattern), "Суффиксный автомат");
            }
        }
    }

    private static void Graphs()
    {
        Random random = new(91);
        for (int test = 0; test < 50; test++)
        {
            int n = 2 + test % 5;
            List<WeightedEdge> edges = [];
            for (int a = 0; a < n; a++)
                for (int b = 0; b < n; b++)
                    if (a != b && random.Next(3) == 0)
                        edges.Add(new(a, b, random.Next(5)));
            var data = edges.ToArray();
            long[] expected = S06T06.Canonical.BellmanFord(n, data, 0);
            Check.Sequence(expected, S06T06.Canonical.Dijkstra(n, data, 0), "Дейкстра без кучи");
            Check.Sequence(expected, S06T06.Modern.Dijkstra(n, data, 0), "Дейкстра с кучей");
            long[,] all = S06T06.Canonical.FloydWarshall(n, data);
            Check.Sequence(expected, Enumerable.Range(0, n).Select(v => all[0, v]), "Флойд");
            var binary = data.Select(e => e with { Weight = e.Weight % 2 }).ToArray();
            Check.Sequence(S06T06.Canonical.BellmanFord(n, binary, 0), S06T06.Modern.ZeroOneBfs(n, binary, 0), "0–1 BFS");
            var dag = data.Where(e => e.From < e.To).Select(e => e with { Weight = e.Weight - 3 }).ToArray();
            Check.Sequence(S06T06.Canonical.BellmanFord(n, dag, 0), S06T06.Canonical.Dag(n, dag, 0), "Пути в DAG");
            int[][] graph = Enumerable.Range(0, n).Select(v => data.Where(e => e.From == v).Select(e => e.To).ToArray()).ToArray();
            int[] first = S11T05.Canonical.Kosaraju(graph);
            int[] second = S11T05.Modern.Tarjan(graph);
            int[][] reach = Enumerable.Range(0, n).Select(v => S06T02.Canonical.Distances(graph, v)).ToArray();
            for (int a = 0; a < n; a++)
                for (int b = 0; b < n; b++)
                {
                    bool mutual = reach[a][b] >= 0 && reach[b][a] >= 0;
                    Check.Equal(mutual, first[a] == first[b], "SCC Косарайю");
                    Check.Equal(mutual, second[a] == second[b], "SCC Тарьян");
                }
            int[,] capacities = new int[n, n];
            foreach (var edge in data)
                capacities[edge.From, edge.To] = edge.Weight;
            long cut = long.MaxValue;
            for (int mask = 0; mask < 1 << n; mask++)
            {
                if ((mask & 1) == 0 || (mask & (1 << (n - 1))) != 0)
                    continue;
                long value = 0;
                for (int a = 0; a < n; a++)
                    for (int b = 0; b < n; b++)
                        if ((mask & (1 << a)) != 0 && (mask & (1 << b)) == 0)
                            value += capacities[a, b];
                cut = Math.Min(cut, value);
            }
            Check.Equal(cut, S11T07.Canonical.Maximum(capacities, 0, n - 1), "Форд — Фалкерсон против всех разрезов");
            var flow = S11T07.Modern.Maximum(capacities, 0, n - 1);
            Check.Equal(cut, flow.Flow, "Эдмондс — Карп против всех разрезов");
            long actualCut = 0;
            for (int a = 0; a < n; a++)
                for (int b = 0; b < n; b++)
                    if (flow.SourceSide[a] && !flow.SourceSide[b])
                        actualCut += capacities[a, b];
            Check.Equal(flow.Flow, actualCut, "Возвращённый минимальный разрез");
            // Случайный маршрут гарантирует существование эйлерова пути, включая петли и повторы.
            int[] walk = Enumerable.Range(0, 8).Select(_ => random.Next(n)).ToArray();
            var directed = walk.Zip(walk.Skip(1), (a, b) => (From: a, To: b)).ToArray();
            int[,] undirected = new int[directed.Length, 2];
            for (int i = 0; i < directed.Length; i++)
            {
                undirected[i, 0] = directed[i].From;
                undirected[i, 1] = directed[i].To;
            }
            ValidateEuler(directed, S11T06.Modern.Directed(n, directed), false);
            ValidateEuler(directed, S11T06.Canonical.Undirected(n, undirected), true);
        }
    }

    private static void ValidateEuler((int From, int To)[] edges, int[] route, bool undirected)
    {
        (int, int) Key(int a, int b) => undirected && a > b ? (b, a) : (a, b);
        var expected = edges.GroupBy(e => Key(e.From, e.To)).ToDictionary(g => g.Key, g => g.Count());
        var actual = route.Zip(route.Skip(1), (a, b) => Key(a, b)).GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count());
        Check.Equal(edges.Length + 1, route.Length, "Длина эйлерова пути");
        Check.Equal(expected.Count, actual.Count, "Набор рёбер маршрута");
        foreach (var (edge, count) in expected)
            Check.Equal(count, actual.GetValueOrDefault(edge), "Каждое ребро ровно раз");
    }

    private static void Structures()
    {
        Random random = new(101);
        for (int n = 0; n <= 20; n++)
        {
            int[] data = new int[n];
            S11T01.Canonical fenwick = new(n);
            S11T01.Modern<long> generic = new(n);
            S11T02.Canonical segment = new(data);
            S11T02.Modern<long> aggregate = new(new long[n], 0, (a, b) => a + b);
            S11T02.LazySum lazy = new(n);
            S11T03.Canonical blocks = new(data);
            for (int step = 0; step < 30; step++)
            {
                if (n > 0)
                {
                    int index = random.Next(n);
                    int value = random.Next(-10, 11);
                    long delta = (long)value - data[index];
                    data[index] = value;
                    fenwick.Add(index, delta);
                    generic.Add(index, delta);
                    segment.Set(index, value);
                    aggregate.Set(index, value);
                    blocks.Set(index, value);
                    lazy.Add(index, index + 1, delta);
                }
                int left = random.Next(n + 1);
                int right = random.Next(left, n + 1);
                long expected = data.Skip(left).Take(right - left).Sum(x => (long)x);
                Check.Equal(expected, fenwick.Sum(left, right), "Фенвик");
                Check.Equal(expected, generic.Prefix(right) - generic.Prefix(left), "Generic Фенвик");
                Check.Equal(expected, segment.Sum(left, right), "Рекурсивное дерево отрезков");
                Check.Equal(expected, aggregate.Query(left..right), "Обобщённое дерево отрезков");
                Check.Equal(expected, blocks.Sum(left, right), "Корневая декомпозиция");
                Check.Equal(expected, lazy.Sum(left, right), "Ленивое дерево");
            }
            if (n > 0)
            {
                int[] parent = Enumerable.Range(0, n).Select(i => i == 0 ? 0 : random.Next(i)).ToArray();
                S11T04.Canonical slow = new(parent);
                S11T04.Modern fast = new(parent);
                for (int a = 0; a < n; a++)
                    for (int b = 0; b < n; b++)
                        Check.Equal(slow.Lca(a, b), fast.Lca(a, b), "Двоичные подъёмы");
            }
        }
        S05T02.Canonical bst = new();
        S05T03.Canonical avl = new();
        HashSet<int> known = [];
        S05T04.Canonical heap = new();
        List<int> input = [];
        for (int i = 0; i < 100; i++)
        {
            int key = random.Next(-30, 31);
            bst.Add(key);
            avl.Add(key);
            known.Add(key);
            heap.Add(key);
            input.Add(key);
            Check.Equal(true, avl.Contains(key), "Поиск после AVL-поворотов");
        }
        foreach (int key in known)
        {
            Check.Equal(true, bst.Contains(key), "Поиск BST");
            bst.Remove(key);
            Check.Equal(false, bst.Contains(key), "Удаление BST");
        }
        Check.Sequence(input.Order(), Enumerable.Range(0, input.Count).Select(_ => heap.Pop()), "Собственная куча");
        S12T01.Canonical slowCache = new(3);
        S12T01.Modern fastCache = new(3);
        for (int i = 0; i < 100; i++)
        {
            int key = random.Next(6);
            if (random.Next(2) == 0)
            {
                slowCache.Put(key, i);
                fastCache.Put(key, i);
            }
            else
            {
                bool a = slowCache.TryGet(key, out int x);
                bool b = fastCache.TryGet(key, out int y);
                Check.Equal(a, b, "LRU: попадание");
                if (a)
                    Check.Equal(x, y, "LRU: значение");
            }
        }
    }

    private static void DynamicProgramming()
    {
        Random random = new(131);
        for (int test = 0; test < 60; test++)
        {
            int[] payments = Enumerable.Range(0, test % 9).Select(_ => random.Next(-3, 9)).ToArray();
            long expected = 0;
            int lis = 0;
            for (int mask = 0; mask < 1 << payments.Length; mask++)
            {
                int[] chosen = Enumerable.Range(0, payments.Length).Where(i => (mask & (1 << i)) != 0).Select(i => payments[i]).ToArray();
                if ((mask & (mask << 1)) == 0)
                    expected = Math.Max(expected, chosen.Sum(x => (long)x));
                if (chosen.Zip(chosen.Skip(1), (a, b) => a < b).All(x => x))
                    lis = Math.Max(lis, chosen.Length);
            }
            Check.Equal(expected, S07T02.Canonical.NonAdjacent(payments), "Несоседние дни: перебор");
            Check.Equal(expected, S07T02.Modern.NonAdjacent(payments), "Сжатое ДП");
            Check.Equal(lis, S07T05.Canonical.Lis(payments), "Квадратичная LIS");
            Check.Equal(lis, S07T05.Modern.Lis(payments), "LIS за n log n");
            int[] weights = payments.Select(x => Math.Abs(x) + 1).ToArray();
            int capacity = random.Next(12);
            long knapsack = 0;
            for (int mask = 0; mask < 1 << payments.Length; mask++)
            {
                int weight = 0;
                long benefit = 0;
                for (int i = 0; i < payments.Length; i++)
                    if ((mask & (1 << i)) != 0)
                    {
                        weight += weights[i];
                        benefit += payments[i];
                    }
                if (weight <= capacity)
                    knapsack = Math.Max(knapsack, benefit);
            }
            Check.Equal(knapsack, S07T04.Canonical.ZeroOne(weights, payments, capacity), "Рюкзак: перебор");
            Check.Equal(knapsack, S07T04.Modern.ZeroOne(weights, payments, capacity), "Рюкзак: одна строка");
        }
    }

    private static void EdgeCases()
    {
        S11T02.LazySum lazy = new(7);
        long[] expected = new long[7];
        foreach (var (left, right, delta) in new[] { (0, 7, 3L), (2, 6, -2L), (0, 3, 5L), (4, 4, 99L) })
        {
            lazy.Add(left, right, delta);
            for (int i = left; i < right; i++)
                expected[i] += delta;
            for (int a = 0; a <= 7; a++)
                for (int b = a; b <= 7; b++)
                    Check.Equal(expected.Skip(a).Take(b - a).Sum(), lazy.Sum(a, b), "Пересекающиеся ленивые обновления");
        }
        S11T02.Modern<string> text = new(["a", "b", "c", "d", "e"], "", (a, b) => a + b);
        Check.Equal("abcde", text.Query(..), "Некоммутативный агрегат при n=5");
        text.Set(2, "X");
        Check.Equal("bXd", text.Query(1..4), "Порядок при обновлении агрегата");
        S12T01.Modern emptyCache = new(0);
        emptyCache.Put(1, 5);
        Check.Equal(false, emptyCache.TryGet(1, out _), "Нулевая ёмкость LRU");
        Check.Equal(2_147_483_648L, S09T02.Canonical.Gcd(int.MinValue, 0), "НОД с int.MinValue");
        Check.Equal(3, S03T03.Canonical.LongestWithinBudget([0, 0, 0], 0), "Нулевые длительности окна");
        Check.Sequence(new[] { 0, 2 }, S10T03.Modern.Find("\0a\0", "\0"), "Разделитель Z не зависит от символов текста");
        Check.Equal(0L, S09T03.Canonical.Power(-2, 0, 1), "Нулевая степень по модулю 1");
        for (int modulus = 2; modulus < 25; modulus++)
            for (int value = -25; value <= 25; value++)
                if (S09T02.Canonical.Gcd(value, modulus) == 1)
                    Check.Equal(1L, ((value * S09T03.Canonical.Inverse(value, modulus)) % modulus + modulus) % modulus, "Обратный элемент");

        Random random = new(151);
        for (int test = 0; test < 20; test++)
        {
            int n = 1 + test % 5;
            int[,] costs = new int[n, n];
            for (int a = 0; a < n; a++)
                for (int b = 0; b < n; b++)
                    costs[a, b] = random.Next(1, 10);
            bool[] taken = new bool[n];
            long optimum = long.MaxValue;
            Assign(0, 0);
            Check.Equal(optimum, S07T08.Canonical.Assignment(costs), "Назначение против перестановок");
            Check.Equal(optimum, S07T08.Modern.Assignment(costs), "Назначение с PopCount");
            long tour = long.MaxValue;
            Array.Fill(taken, false);
            taken[0] = true;
            if (n == 1)
                tour = 0;
            else
                Visit(0, 1, 0);
            Check.Equal(tour, S07T08.Modern.Tour(costs), "Цикл коммивояжёра против перестановок");
            void Assign(int worker, long sum)
            {
                if (worker == n)
                {
                    optimum = Math.Min(optimum, sum);
                    return;
                }
                for (int task = 0; task < n; task++)
                    if (!taken[task])
                    {
                        taken[task] = true;
                        Assign(worker + 1, sum + costs[worker, task]);
                        taken[task] = false;
                    }
            }
            void Visit(int last, int count, long sum)
            {
                if (count == n)
                {
                    tour = Math.Min(tour, sum + costs[last, 0]);
                    return;
                }
                for (int next = 1; next < n; next++)
                    if (!taken[next])
                    {
                        taken[next] = true;
                        Visit(next, count + 1, sum + costs[last, next]);
                        taken[next] = false;
                    }
            }
        }
        WeightedEdge[] roads = [new(0, 1, -2), new(1, 2, 1), new(0, 2, 5)];
        Check.Equal(-1L, S06T07.Canonical.Kruskal(3, roads), "Остов с отрицательным ребром");
        Check.Equal(-1L, S06T07.Modern.Prim(3, roads), "Прим допускает отрицательное ребро");
        Check.Throws<ArgumentException>(() => S11T06.Modern.Directed(4, [(0, 1), (1, 0), (2, 3), (3, 2)]), "Несвязные эйлеровы циклы");
        Check.Equal(true, S09T06.Modern.Intersects(new(0, 0), new(0, 0), new(-1, 0), new(1, 0)), "Вырожденный отрезок-точка");
        Check.Equal(false, S09T06.Modern.Intersects(new(2, 0), new(2, 0), new(-1, 0), new(1, 0)), "Точка за границами");
    }
}
