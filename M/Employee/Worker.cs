using M.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class Worker : IEmployee, IStrategy //changed interfaces
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public string Position = "Worker"; //Changed to Worker

        private List<IEmployee> _subordinate;

        public Worker(string name, int salary)
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
        }


        List<IEmployee> IStrategy.Subordinate()
        {
            throw new Exception("У цього робітника не може бути підлеглих");
        }
    }
}
