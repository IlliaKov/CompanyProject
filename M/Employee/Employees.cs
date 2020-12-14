using System;
using System.Collections.Generic;
using System.Text;

namespace M
{

    public class Employees
    {

        public Interface.IStrategy Strategy { get; set; }

        public Employees(Interface.IStrategy strategy)
        {
            Strategy = strategy;
        }

        public List<Interface.IEmployee> Subordinate()
        {
            return Strategy.Subordinate();
        }

    }
}
