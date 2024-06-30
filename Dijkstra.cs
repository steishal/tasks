public class DijkstraAlgorithm
{
    public static Dictionary<char, int> Dijkstra(Dictionary<char, List<(char, int)>> graph, char startNode)
    {
        Dictionary<char, int> distance = new Dictionary<char, int>();
        List<char> unvisited = new List<char>();

        foreach (char node in graph.Keys)
        {
            distance[node] = int.MaxValue;
            unvisited.Add(node);
        }

        distance[startNode] = 0;

        while (unvisited.Count > 0)
        {
            char currentNode = GetClosestNode(unvisited, distance);
            unvisited.Remove(currentNode);

            foreach ((char, int) edge in graph[currentNode])
            {
                int alternateRouteDistance = distance[currentNode] + edge.Item2;
                if (alternateRouteDistance < distance[edge.Item1])
                {
                    distance[edge.Item1] = alternateRouteDistance;
                }
            }
        }

        return distance;
    }

    private static char GetClosestNode(List<char> unvisited, Dictionary<char, int> distance)
    {
        int minDistance = int.MaxValue;
        char closestNode = ' ';

        foreach (char node in unvisited)
        {
            if (distance[node] < minDistance)
            {
                minDistance = distance[node];
                closestNode = node;
            }
        }

        return closestNode;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<char, List<(char, int)>> graph = new Dictionary<char, List<(char, int)>>
        {
            {'A', new List<(char, int)> {('B', 2), ('C', 3), ('D', 4)}},
            {'B', new List<(char, int)> {('A', 2), ('D', 5)}},
            {'C', new List<(char, int)> {('A', 3), ('D', 1)}},
            {'D', new List<(char, int)> {('A', 4), ('B', 5), ('C', 1)}}
        };

        char startNode = 'A';
        Dictionary<char, int> shortestPaths = DijkstraAlgorithm.Dijkstra(graph, startNode);

        foreach (var pair in shortestPaths)
        {
            Console.WriteLine($"Кратчайшее расстояние от {startNode} до {pair.Key}: {pair.Value}");
        }
    }
}

