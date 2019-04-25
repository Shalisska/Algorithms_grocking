using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Code
{
    public class HashTables
    {
        Dictionary<string, bool> _voted;

        public bool CheckVoter(string name)
        {
            if (_voted == null)
                _voted = new Dictionary<string, bool>();

            if (_voted.ContainsKey(name))
                return false;
            else
            {
                _voted.Add(name, true);
                return true;
            }
        }
    }
}
