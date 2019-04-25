using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Code
{
    public class BreadthFirstSearch
    {
        private Dictionary<string, string[]> _graph;

        private Dictionary<string, string[]> Graph
        {
            get => GetGraph();
            set => _graph = value;
        }

        Dictionary<string, string[]> GetGraph()
        {
            var graph = new Dictionary<string, string[]>
            {
                ["you"] = new[] { "alice", "bob", "claire" },
                ["alice"] = new[] { "peggy" },
                ["bob"] = new[] { "anuj", "peggy" },
                ["claire"] = new[] { "tom", "jonny" },
                ["peggy"] = Array.Empty<string>(),
                ["anuj"] = Array.Empty<string>(),
                ["tom"] = Array.Empty<string>(),
                ["jonny"] = Array.Empty<string>()
            };

            return graph;
        }

        bool PersonIsSeller(string name)
        {
            return name.EndsWith("m");
        }

        public string SearchSeller(string name)
        {
            var searchQueue = new Queue<string>(Graph[name]);
            var searched = new List<string>();

            while (searchQueue.Any())
            {
                var person = searchQueue.Dequeue();

                if (!searched.Contains(person))
                {
                    if (PersonIsSeller(person))
                        return person;
                    else
                    {
                        searchQueue = new Queue<string>(searchQueue.Concat(Graph[person]));
                        searched.Add(person);
                    }
                }
            }

            return string.Empty;
        }
    }
}
