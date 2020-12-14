using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class Worker : Interface.IEmployee, Interface.IStrategy
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public string Position = "Робітник";

        private List<Interface.IEmployee> _subordinate;

        public Worker(string name, int salary)
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
        }


        List<Interface.IEmployee> Interface.IStrategy.Subordinate()
        {
            throw new Exception("У цього робітника не може бути підлеглих");
        }
    }
}
