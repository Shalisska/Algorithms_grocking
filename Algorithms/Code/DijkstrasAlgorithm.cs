using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Code
{
    public class DijkstrasAlgorithm
    {
        private Dictionary<string, Dictionary<string, double>> _graph;
        private Dictionary<string, double> _costs;
        private Dictionary<string, string> _parents;
        private List<string> _processed;

        float _infinity => float.PositiveInfinity;

        public Dictionary<string, Dictionary<string, double>> Graph { get => _graph ?? SetGraph(); set => _graph = value; }
        public Dictionary<string, double> Costs { get => _costs ?? SetCosts(); set => _costs = value; }
        public Dictionary<string, string> Parents { get => _parents ?? SetParents(); set => _parents = value; }
        public List<string> Processed { get => _processed ?? new List<string>(); set => _processed = value; }

        Dictionary<string, Dictionary<string, double>> SetGraph()
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

        Dictionary<string, double> SetCosts()
        {
            var costs = new Dictionary<string, double>
            {
                ["a"] = 6,
                ["b"] = 2,
                ["fin"] = _infinity
            };

            return costs;
        }

        Dictionary<string, string> SetParents()
        {
            var parents = new Dictionary<string, string>
            {
                ["a"] = "start",
                ["b"] = "start",
                ["fin"] = string.Empty
            };

            return parents;
        }

        KeyValuePair<string,double> FindLowestCostNode()
        {
            var min = Costs.Select(c => c.Value).Min();
            var node = Costs.FirstOrDefault(n => !Processed.Contains(n.Key) && n.Value == min);
            return node;
        }
    }
}
