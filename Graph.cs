public class Graph<T>
{
    private Dictionary<T, List<T>> list;
    public Graph()
    {
        list = new Dictionary<T, List<T>>();
    }
    public void AddVert(T vert)
    {
        if (!list.ContainsKey(vert))
        {
            list[vert] = new List<T>();
        }
    }
    public void AddEdge(T source, T anothervert)
    {
        if (!GetNeighbors(source).Contains(anothervert))
        {
            if (!list.ContainsKey(source))
            {
                AddVert(source);
            }
            if (!list.ContainsKey(anothervert))
            {
                AddVert(anothervert);
            }
            list[source].Add(anothervert);
        }

    }
    public void RemoveVert(T vert)
    {
        if (list.ContainsKey(vert))
        {
            list[vert] = null;
        }
        if (!list.ContainsKey(vert))
        {
            throw new KeyNotFoundException("Key not found in hash table");
        }

    }
    public void RemoveEdge(T source, T anothervert)
    {
        if (list.ContainsKey(source) && list.ContainsKey(anothervert))
        {
            list[source].Remove(anothervert);
        }

    }
    public List<T> GetNeighbors(T vert)
    {
        if (list.ContainsKey(vert))
        {
            return list[vert];
        }
        return new List<T>();

    }

}
class Program
{
    static void Main()
    {
        Graph<string> graph = new Graph<string>();
        graph.AddVert("A");
        graph.AddVert("B");
        graph.AddVert("C");
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        graph.AddEdge("A", "C");
        Console.WriteLine("Neighbors of A:");
        foreach (var neighbor in graph.GetNeighbors("A"))
        {
            Console.WriteLine(neighbor);
        }

        graph.RemoveEdge("A", "B");

        Console.WriteLine("после удаления A -> B:");
        Console.WriteLine("соседи A:");
        foreach (var neighbor in graph.GetNeighbors("A"))
        {
            Console.WriteLine(neighbor);
        }


    }
}

