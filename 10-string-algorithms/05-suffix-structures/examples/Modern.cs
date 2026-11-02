namespace AlgoTraining.Topics.S10T05;

// Современная версия: возможности C# и стандартной библиотеки .NET.
public static class Modern
{
    public static int[] SuffixArray(string text)
    {
        var n = text.Length;
        var order = Enumerable.Range(0, n).ToArray();
        var rank = text.Select(c => (int)c).ToArray();
        for (var width = 1; width < n; width = width > n / 2 ? n : width * 2)
        {
            var step = width;
            order = order.OrderBy(i => rank[i]).ThenBy(i => i + step < n ? rank[i + step] : -1).ToArray();
            int[] next = new int[n];
            for (var i = 1; i < n; i++)
            {
                var a = order[i - 1];
                var b = order[i];
                var different = rank[a] != rank[b] || (a + step < n ? rank[a + step] : -1) != (b + step < n ? rank[b + step] : -1);
                next[b] = next[a] + (different ? 1 : 0);
            }
            rank = next;
        }
        return order; // Удвоение + сравнивающая сортировка: O(n log² n), O(n) пик памяти.
    }
    public static int[] Lcp(string text, int[] suffixes)
    {
        if (suffixes.Length != text.Length)
            throw new ArgumentException("Неверная длина массива.");
        int[] rank = new int[text.Length];
        int[] lcp = new int[text.Length];
        for (var i = 0; i < suffixes.Length; i++)
            rank[suffixes[i]] = i;
        var common = 0;
        for (var start = 0; start < text.Length; start++)
        {
            var position = rank[start];
            if (position == 0)
            {
                common = 0;
                continue;
            }
            var previous = suffixes[position - 1];
            while (start + common < text.Length && previous + common < text.Length && text[start + common] == text[previous + common])
                common++;
            lcp[position] = common;
            if (common > 0)
                common--;
        }
        return lcp; // Касаи: O(n). Вход suffixes должен быть верным суффиксным массивом.
    }
}
public sealed class SuffixAutomaton
{
    private sealed class State
    {
        public int Length; public int Link = -1; public Dictionary<char, int> Next = [];
    }
    private readonly List<State> states = [new()];
    private int last;
    public SuffixAutomaton(string text)
    {
        foreach (var symbol in text)
            Extend(symbol);
    }
    private void Extend(char symbol)
    {
        var current = states.Count;
        states.Add(new()
        {
            Length = states[last].Length + 1
        });
        var p = last;
        while (p >= 0 && !states[p].Next.ContainsKey(symbol))
        {
            states[p].Next[symbol] = current;
            p = states[p].Link;
        }
        if (p < 0)
            states[current].Link = 0;
        else
        {
            var q = states[p].Next[symbol];
            if (states[p].Length + 1 == states[q].Length)
                states[current].Link = q;
            else
            {
                var clone = states.Count;
                states.Add(new()
                {
                    Length = states[p].Length + 1,
                    Link = states[q].Link,
                    Next = new(states[q].Next)
                });
                while (p >= 0 && states[p].Next.TryGetValue(symbol, out var next) && next == q)
                {
                    states[p].Next[symbol] = clone;
                    p = states[p].Link;
                }
                states[q].Link = states[current].Link = clone;
            }
        }
        last = current;
    }
    public bool Contains(string pattern)
    {
        var state = 0;
        foreach (var symbol in pattern)
        {
            if (!states[state].Next.TryGetValue(symbol, out var next))
                return false;
            state = next;
        }
        return true;
    }
    // Ожидаемо O(n) построение для словарных переходов, O(n) состояний, O(m) поиск.
}
