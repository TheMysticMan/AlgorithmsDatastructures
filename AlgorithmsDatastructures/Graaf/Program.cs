using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryHeap;

namespace Graaf
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddEdge("v3", "v1", 1);
            graph.AddEdge("v3", "v6", 1);
            graph.AddEdge("v1", "v4", 1);
            graph.AddEdge("v4", "v3", 1);
            graph.AddEdge("v4", "v6", 1);
            graph.AddEdge("v1", "v2", 1);
            graph.AddEdge("v2", "v4", 1);
            graph.AddEdge("v2", "v5", 1);
            graph.AddEdge("v4", "v5", 1);
            graph.AddEdge("v4", "v7", 1);
            graph.AddEdge("v5", "v7", 1);
            graph.AddEdge("v7", "v6", 1);

            graph.CalculateCostsUnweighed("v3");

            var graph2 = new Graph();
            graph2.AddEdge("v3", "v1", 4);
            graph2.AddEdge("v3", "v6", 5);
            graph2.AddEdge("v1", "v4", 1);
            graph2.AddEdge("v1", "v2", 2);
            graph2.AddEdge("v4", "v6", 8);
            graph2.AddEdge("v4", "v7", 4);
            graph2.AddEdge("v4", "v5", 2);
            graph2.AddEdge("v4", "v3", 2);
            graph2.AddEdge("v2", "v4", 3);
            graph2.AddEdge("v2", "v5", 10);
            graph2.AddEdge("v5", "v7", 6);
            graph2.AddEdge("v7", "v6", 1);

            Console.WriteLine();
            graph2.CalculateCostsWeighed("v1");
        }
    }

    public class Graph
    {
        private readonly Dictionary<String, Vertex> _vertexMap = new Dictionary<string, Vertex>();

        public void AddEdge(String sourceName, String destName, double cost)
        {
            Vertex v = GetVertex(sourceName);
            Vertex w = GetVertex(destName);
            v.Adj.Add(new Edge(w, cost));
        }

        private Vertex GetVertex(string name)
        {

            var retVal = default(Vertex);
            if (_vertexMap.ContainsKey(name))
            {
                retVal = _vertexMap[name];
            }
            else
            {
                retVal = new Vertex(name);
                _vertexMap[name] = retVal;
            }

            return retVal;
        }

        public void CalculateCostsUnweighed(string start)
        {
            Queue<Vertex> q = new Queue<Vertex>();
            foreach (var keyValuePair in _vertexMap)
            {
                keyValuePair.Value.Dist = Double.PositiveInfinity;
                keyValuePair.Value.Previous = null;
            }

            var startVertex = GetVertex(start);
            startVertex.Dist = 0;
            q.Enqueue(startVertex);

            while (q.Count > 0)
            {
                Vertex v = q.Dequeue();
                Console.WriteLine($"{v.Name}: {v.Dist}");
                v.Adj.ForEach(w =>
                {
                    if (w.Dest.Dist == Double.PositiveInfinity)
                    {
                        w.Dest.Dist = v.Dist + 1;
                        w.Dest.Previous = v;
                        q.Enqueue(w.Dest);
                    }
                });
            }
        }

        public void CalculateCostsWeighed(string start)
        {
            var priorityQueue = new BinaryHeap<Vertex>(_vertexMap.Count);

            foreach (var keyValuePair in _vertexMap)
            {
                keyValuePair.Value.Dist = Double.PositiveInfinity;
                keyValuePair.Value.Previous = null;
            }

            var startVertex = GetVertex(start);
            startVertex.Dist = 0;
            priorityQueue.Insert(startVertex);

            while (priorityQueue.Length > 0)
            {
                var v = priorityQueue.DeleteMin();
                if (!v.Known)
                {
                    Console.WriteLine($"{v.Name}: {v.Dist}");
                }
                v.Known = true;
                v.Adj.ForEach(we =>
                {
                    var w = we.Dest;
                    if (!w.Known)
                    {
                        if (v.Dist + we.Cost < w.Dist)
                        {
                            w.Dist = v.Dist + we.Cost;
                            w.Previous = v;
                            priorityQueue.Insert(w);
                        }
                    }
                });
            }
        }
    }

    internal class VertexNotFoundException : Exception
    {
        public VertexNotFoundException(string name) : base($"Could not find Vertex with name: {name}")
        {}
    }

    public class Vertex : IComparable
    {
        public Vertex(string name)
        {
            Name = name;
        }

        public String Name { get; set; }
        public List<Edge> Adj { get; set; } = new List<Edge>();

        /// <summary>
        /// Used for shortest path algorithms
        /// </summary>
        public double Dist { get; set; }
        /// <summary>
        /// Previous vertex on shortest path
        /// </summary>
        public Vertex Previous { get; set; }

        public bool Known { get; set; }

        public int CompareTo(object obj)
        {
            var to = (Vertex) obj;
            if (to.Dist > Dist)
            {
                return -1;
            }
            else if (to.Dist == Dist)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public class Edge
    {
        public Edge(Vertex vertex, double cost)
        {
            Dest = vertex;
            Cost = cost;
        }

        public Vertex Dest { get; set; }
        public double Cost { get; set; } = 1;
    }

}
