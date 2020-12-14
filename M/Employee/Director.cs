using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class Director : Interface.IEmployee, Interface.IStrategy
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public string Position = "Директор";

        private List<Interface.IEmployee> _subordinate;

        public Director(string name, int salary)
        {
            Name = name;
            Salary = salary;
            _subordinate = new List<Interface.IEmployee>();
        }


        public void Add(Interface.IEmployee employee)
        {
            _subordinate.Add(employee);
        }


        public void Accept(Interface.IEmployeeVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var employee in _subordinate)
            {
                employee.Accept(visitor);
            }

        }

        public List<Interface.IEmployee> Subordinate()
        {
            return _subordinate;
        }
    }
}
