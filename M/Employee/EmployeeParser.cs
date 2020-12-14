using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class EmployeeParser
    {

        public List<string> SortingDirectSubordination(List<Employee> employees)
        {
            List<string> names = new List<string>();
            foreach (var name in employees)
            {
                names.Add(name.Name);
            }
            return names;
        }


        public List<string> SearchPosition(List<Employee> employees, string position)
        {
            List<string> names = new List<string>();
            foreach (var name in employees)
            {
                if (name.Position == position)
                {
                    names.Add(name.Name);
                }
            }
            return names;
        }

        public List<string> SortingPosition(List<Employee> employees)
        {
            List<string> managers = SearchPosition(employees, "Менеджер");
            List<string> workers = SearchPosition(employees, "Робітник");
            managers.Add("|");
            foreach (string worker in workers)
            {
                managers.Add(worker);
            }
            return managers;
        }

        public string MaxSalary(List<Employee> employees)
        {
            string name = "Робітники відсутні";
            int salary = 0;
            string position = "";

            foreach (var employee in employees)
            {
                if (employee.Salary > salary)
                {
                    name = employee.Name;
                    salary = employee.Salary;
                    position = employee.Position;
                }
            }
            return name;
        }



        public List<string> OverSalary(List<Employee> employees, int setSalary)
        {
            List<string> names = new List<string>();

            foreach (var employee in employees)
            {
                if (setSalary < employee.Salary)
                {
                    names.Add(employee.Name);
                }
            }
            return names;
        }
    }
}
