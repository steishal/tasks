using Internal;
using System.Collections.Generic;

class PrimsAlgorithm
{
    public static void Prim(Dictionary<char, List<(char, int)>> graph)
    {
        int verticesCount = graph.Count;
        int[,] adjacencyMatrix = ConvertToAdjacencyMatrix(graph);
        int[] parent = new int[verticesCount];
        int[] key = new int[verticesCount];
        bool[] mstSet = new bool[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinKey(key, mstSet, verticesCount);
            mstSet[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (adjacencyMatrix[u, v] != 0 && !mstSet[v] && adjacencyMatrix[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = adjacencyMatrix[u, v];
                }
            }
        }

        PrintMST(parent, verticesCount, adjacencyMatrix);
    }

    private static int[,] ConvertToAdjacencyMatrix(Dictionary<char, List<(char, int)>> graph)
    {
        int verticesCount = graph.Count;
        int[,] adjacencyMatrix = new int[verticesCount, verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            foreach (var neighbor in graph[(char)(i + 'A')])
            {
                adjacencyMatrix[i, neighbor.Item1 - 'A'] = neighbor.Item2;
            }
        }

        return adjacencyMatrix;
    }

    private static int MinKey(int[] key, bool[] mstSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < verticesCount; v++)
        {
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static void PrintMST(int[] parent, int verticesCount, int[,] graph)
    {
        Console.WriteLine("Ребро   Вес");
        for (int i = 1; i < verticesCount; i++)
        {
            Console.WriteLine((char)(parent[i] + 'A') + " - " + (char)(i + 'A') + "   " + graph[i, parent[i]]);
        }
    }

    static void Main()
    {
        Dictionary<char, List<(char, int)>> graph = new Dictionary<char, List<(char, int)>> {
            {'A', new List<(char, int)> {('B', 2), ('C', 3), ('D', 4)}},
            {'B', new List<(char, int)> {('A', 2), ('D', 5)}},
            {'C', new List<(char, int)> {('A', 3), ('D', 1)}},
            {'D', new List<(char, int)> {('A', 4), ('B', 5), ('C', 1)}}
        };

        Prim(graph);
    }
}

