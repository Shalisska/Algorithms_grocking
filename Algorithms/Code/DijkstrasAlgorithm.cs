using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Code
{
    public class DijkstrasAlgorithm
    {
        public DijkstrasAlgorithm(int number)
        {
            if (number == 1)
            {
                Graph = GetGraph1();
                Start = "book";
                Fin = "piano";
            }
            else
            {
                Graph = GetGraph();
                Start = "start";
                Fin = "fin";
            }

            Costs = GetCosts(Graph, Start);
            Parents = GetParents(Graph, Start);
            Processed = new List<string>();
        }

        public DijkstrasAlgorithm(Dictionary<string, Dictionary<string, double>> graph, string start, string fin)
        {
            Graph = graph;
            Start = start;
            Fin = fin;
            Costs = GetCosts(Graph, Start);
            Parents = GetParents(Graph, Start);
            Processed = new List<string>();
        }
        public DijkstrasAlgorithm GetDijkstrasAlgorithm(int number)
        {
            var graph = number == 1 ? GetGraph1() : GetGraph();

            if (number == 1)
            {
                return new DijkstrasAlgorithm(GetGraph1(), "book", "piano");
            }
            else
            {
                return new DijkstrasAlgorithm(GetGraph(), "start", "fin");
            }
        }

        float _infinity => float.PositiveInfinity;

        public Dictionary<string, Dictionary<string, double>> Graph { get; set; }
        public Dictionary<string, double> Costs { get; set; }
        public Dictionary<string, string> Parents { get; set; }
        public List<string> Processed { get; set; }
        public string Start { get; set; }
        public string Fin { get; set; }

        string FindLowestCostNode()
        {
            var lowestCost = double.PositiveInfinity;
            string lowestCostNode = null;
            var nodes = Costs.Where(n => !Processed.Contains(n.Key));

            foreach(var node in nodes)
            {
                var cost = node.Value;

                if (cost < lowestCost)
                {
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }

            return lowestCostNode;
        }

        Dictionary<string,double> GetCosts(Dictionary<string, Dictionary<string, double>> graph, string startNode)
        {
            if (graph == null || !graph.ContainsKey(startNode))
                return null;

            var dict = new Dictionary<string, double>();
            var nodesList = graph.Where(n => n.Key != startNode).Select(n => n.Key);
            var startNeighbors = graph.FirstOrDefault(n => n.Key == startNode).Value;

            if (startNeighbors == null)
                return null;

            foreach(var item in nodesList)
            {
                if (startNeighbors.ContainsKey(item))
                    dict.Add(item, startNeighbors[item]);
                else
                    dict.Add(item, _infinity);
            }

            return dict;
        }

        Dictionary<string, string> GetParents(Dictionary<string, Dictionary<string, double>> graph, string startNode)
        {
            if (graph == null || !graph.ContainsKey(startNode))
                return null;

            var dict = new Dictionary<string, string>();
            var nodesList = graph.Where(n => n.Key != startNode).Select(n => n.Key);
            var startNeighbors = graph.FirstOrDefault(n => n.Key == startNode).Value;

            if (startNeighbors == null)
                return null;

            foreach (var item in nodesList)
            {
                if (startNeighbors.ContainsKey(item))
                    dict.Add(item, startNode);
                else
                    dict.Add(item, string.Empty);
            }

            return dict;
        }

        void FindPath()
        {
            var node = FindLowestCostNode();

            while (node != null)
            {
                var cost = Costs[node];
                var neighbors = Graph[node];

                foreach(var neighbor in neighbors.Keys)
                {
                    var newCost = cost + neighbors[neighbor];

                    if (Costs[neighbor] > newCost)
                    {
                        Costs[neighbor] = newCost;
                        Parents[neighbor] = node;
                    }
                }

                Processed.Add(node);
                node = FindLowestCostNode();
            }
        }

        public Dictionary<string, double> GetResult()
        {
            return GetResult(Start, Fin);
        }

        public Dictionary<string, double> GetResult(string start, string fin)
        {
            FindPath();
            var path = new Dictionary<string, double>();

            var node = fin;

            while (node != start)
            {
                var parent = Parents[node];
                path.Add(node, Graph[parent][node]);
                node = parent;
            }

            if (path == null)
                return null;

            var newPath = path.Reverse();

            return new Dictionary<string, double>(newPath);
        }

        Dictionary<string, Dictionary<string, double>> GetGraph()
        {
            var graph = new Dictionary<string, Dictionary<string, double>>
            {
                ["start"] = new Dictionary<string, double>
                {
                    ["a"] = 6,
                    ["b"] = 2
                },

                ["a"] = new Dictionary<string, double>
                {
                    ["fin"] = 1
                },

                ["b"] = new Dictionary<string, double>
                {
                    ["a"] = 3,
                    ["fin"] = 5
                },

                ["fin"] = new Dictionary<string, double>()
            };

            return graph;
        }

        Dictionary<string, Dictionary<string, double>> GetGraph1()
        {
            var graph1 = new Dictionary<string, Dictionary<string, double>>
            {
                ["book"] = new Dictionary<string, double>
                {
                    ["rare LP"] = 5,
                    ["poster"] = 0
                },
                ["rare LP"] = new Dictionary<string, double>
                {
                    ["guitar"] = 15,
                    ["drum set"] = 20
                },
                ["poster"] = new Dictionary<string, double>
                {
                    ["guitar"] = 30,
                    ["drum set"] = 35
                },
                ["guitar"] = new Dictionary<string, double>
                {
                    ["piano"] = 20
                },
                ["drum set"] = new Dictionary<string, double>
                {
                    ["piano"] = 10
                },
                ["piano"] = new Dictionary<string, double>()
            };

            return graph1;
        }
    }
}
