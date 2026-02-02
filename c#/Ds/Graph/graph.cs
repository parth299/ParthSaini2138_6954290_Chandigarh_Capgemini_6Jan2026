using System;
using System.Collections.Generic;

class Graph<T>
{
    Dictionary<T, List<(T, int)>> adjList;

    public Graph()
    {
        adjList = new Dictionary<T, List<(T, int)>>();
    }

    public void AddEdge(T u, T v, int weight, bool isDirected = false)
    {
        if (!adjList.ContainsKey(u))
            adjList[u] = new List<(T, int)>();

        adjList[u].Add((v, weight));

        if (!isDirected)
        {
            if (!adjList.ContainsKey(v))
                adjList[v] = new List<(T, int)>();

            adjList[v].Add((u, weight));
        }
    }

    public void PrintAdjList() {
        Console.WriteLine("------ Adjacancy List ------");
        foreach(var node in adjList) {
            Console.Write("Node: " + node.Key + " -> [ ");
            foreach(var neightbour in node.Value) {
                Console.Write(neightbour.Item1 + " ");
            }
            Console.WriteLine("]");
        }
        Console.WriteLine("----------------------------");
    }

    public void PrintAdjListWeight() {
        Console.WriteLine("------ Adjacancy List ------");
        foreach(var node in adjList) {
            Console.Write("Node: " + node.Key + " -> [ ");
            foreach(var neightbour in node.Value) {
                Console.Write(neightbour + " ");
            }
            Console.WriteLine("]");
        }
        Console.WriteLine("----------------------------");
    }

    public Dictionary<T, int> DijkstraAlgorithm(
        T source)
    {
        var pq = new PriorityQueue<T, int>();
        var dist = new Dictionary<T, int>();

        foreach (var node in adjList.Keys)
        {
            dist[node] = int.MaxValue;
        }

        dist[source] = 0;
        pq.Enqueue(source, 0);

        while (pq.Count > 0)
        {
            T u = pq.Dequeue();

            foreach (var edge in adjList[u])
            {
                T v = edge.Item1;
                int weight = edge.Item2;

                if (dist[u] != int.MaxValue &&
                    dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }

        return dist;
    }

}
