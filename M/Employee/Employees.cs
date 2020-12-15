using M.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace M
{

    public class Employees
    {

        public IStrategy Strategy { get; set; }

        public Employees(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public List<IEmployee> Subordinate()
        {
            return Strategy.Subordinate();
        }

    }
}
