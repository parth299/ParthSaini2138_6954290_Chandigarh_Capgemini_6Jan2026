class Program {
    public static void Main(string[] args) {
        Graph<int> g = new Graph<int>();
        bool isDirected = false;
        g.AddEdge(0, 1, 4, isDirected);
        g.AddEdge(0, 2, 8, isDirected);
        g.AddEdge(1, 4, 6, isDirected);
        g.AddEdge(2, 3, 2, isDirected);
        g.AddEdge(3, 4, 10, isDirected);

        g.PrintAdjList();

        var dists = g.DijkstraAlgorithm(0);
        
        Console.WriteLine("Dijkstra Results: ");
        foreach(var d in dists) {
            Console.WriteLine(d.Key + " " + d.Value);
        }
    }
}