using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class GetNames : Interface.IEmployeeVisitor
    {
        public List<Employee> Result { get; private set; }

        public void Visit(Worker worker)
        {
            if (Result == null)
            {
                Result = new List<Employee>();
            }

            Result.Add(new Employee { Name = worker.Name, Salary = worker.Salary, Position = worker.Position });
        }

        public void Visit(Manager manager)
        {
            if (Result == null)
            {
                Result = new List<Employee>();
            }
            Result.Add(new Employee { Name = manager.Name, Salary = manager.Salary, Position = manager.Position });
        }

        public void Visit(Director director)
        {
            if (Result == null)
            {
                Result = new List<Employee>();
            }
            Result.Add(new Employee { Name = director.Name, Salary = director.Salary, Position = director.Position });
        }
    }
}
