namespace AlgoTraining.Topics.S06T01;

// Каноничная версия: явные типы и основные шаги без LINQ.
public static class Canonical
{
    public static int[][] FromMatrix(bool[,] matrix)
    {
        int count = matrix.GetLength(0);
        if (count != matrix.GetLength(1))
            throw new ArgumentException("Матрица должна быть квадратной.");
        int[][] result = new int[count][];
        for (int from = 0; from < count; from++)
        {
            List<int> neighbors = new List<int>();
            for (int to = 0; to < count; to++)
                if (matrix[from, to])
                    neighbors.Add(to);
            result[from] = neighbors.ToArray();
        }
        return result; // O(V²), результат O(V+E), направление сохраняется.
    }
}
