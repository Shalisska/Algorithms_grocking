using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Code
{
    public class DijkstrasAlgorithm
    {
        private Dictionary<string, Dictionary<string, double>> _graph;

        float _infinity => float.PositiveInfinity;

        public Dictionary<string, Dictionary<string, double>> Graph
        {
            get
            {
                if (_graph == null)
                    SetGraph();

                return _graph;
            }
            set => _graph = value;
        }

        void SetGraph()
        {
            _graph["start"] = new Dictionary<string, double>
            {
                ["a"] = 6,
                ["b"] = 2
            };

            _graph["a"] = new Dictionary<string, double>
            {
                ["fin"] = 1
            };

            _graph["b"] = new Dictionary<string, double>
            {
                ["a"] = 3,
                ["fin"] = 5
            };

            _graph["fin"] = new Dictionary<string, double>();
        }
    }
}
