using System;
using System.Collections.Generic;
using System.Text;

namespace M.Interface
{
    public interface IEmployeeVisitor
    {
        void Visit(Worker worker);
        void Visit(Manager manager);
        void Visit(Director director);
    }


    public interface IEmployee
    {
        string Name { get; }
        int Salary { get; }
        void Accept(IEmployeeVisitor visitor);
        void Add(Interface.IEmployee employee);
    }

    public interface IStrategy
    {
        List<Interface.IEmployee> Subordinate();
    }
}
