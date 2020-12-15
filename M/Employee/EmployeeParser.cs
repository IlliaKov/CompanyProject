using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M
{
    public class EmployeeParser
    {
        /// returns employees' list in the tree view --- employees instances we passed
        /// employees names in tree view
        public List<string> SortingDirectSubordination(List<Employee> employees)
        {
            var resultList = new List<string>();
            foreach (var emp in employees)
            {
                if (emp.Position == "Director")
                {
                    resultList.Add(emp.Name);
                }

                if (emp.Position == "Manager")
                {
                    resultList.Add($"..{emp.Name}");
                }
                if (emp.Position == "Worker")
                {
                    resultList.Add($"....{emp.Name}");
                }
            }

            return resultList;
        }

        public List<string> SearchPosition(List<Employee> employees, string position)//I used LINQ zaprosi
        {
            return employees.Where(x => x.Position == position).Select(x => x.Name).ToList();
        }

        public List<string> SortingPosition(List<Employee> employees)//I used LINQ zaprosi
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

        public string MaxSalary(List<Employee> employees)//I used LINQ zaprosi
        {
            if (employees.Count == 0) return "There are no employees in list";
            return employees.OrderByDescending(x => x.Salary).First().Name;
        }

        public List<string> OverSalary(List<Employee> employees, int setSalary)//I used LINQ zaprosi
        {
            return employees.Where(x => x.Salary > setSalary).Select(x => x.Name).ToList();
        }
    }
}
