using M.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class Manager : IEmployee, IStrategy
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public string Position = "Manager"; //Changed to Manager

        private List<IEmployee> _subordinate;

        public Manager(string name, int salary)
        {
            Name = name;
            Salary = salary;
            _subordinate = new List<IEmployee>();
        }


        public void Add(IEmployee employee)
        {
            _subordinate.Add(employee);
        }


        public void Accept(IEmployeeVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var employee in _subordinate)
            {
                employee.Accept(visitor);
            }

        }

        public List<IEmployee> Subordinate()
        {
            return _subordinate;
        }
    }
}
