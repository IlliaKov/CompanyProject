using M;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw2_23
{
    class Program
    {

        static void Main(string[] args)
        {
            var director = new Director("andriy", 12000);
            var supplyManager = new Manager("vova", 2900);
            var salesManager = new Manager("pasha", 4000);

            director.Add(supplyManager);
            director.Add(salesManager);

            var workderX = new Worker("misha", 4320);
            var workderY = new Worker("sasha", 1032);

            var workderA = new Worker("roma", 2020);
            var workderB = new Worker("mark", 3195);

            supplyManager.Add(workderX);
            supplyManager.Add(workderY);

            salesManager.Add(workderA);
            salesManager.Add(workderB);


            


            M.Interface.IEmployee employee = director;


            var names = new GetNames();

            employee.Accept(names);

            M.EmployeeParser employeeParser = new EmployeeParser();
            

            while (true)
            {
                Console.WriteLine("1. Сортировка по належності (у вигляді дерева)\n2. Пошук позиції\n3. Сортировка по позиції\n4. Пошук більної зарплати\n5. Пошук більної заплати ніж у\n0. Вийти\n");
                int number = Convert.ToInt32(Console.ReadLine());
                List<string> data = new List<string>() ;


                if (number == 0)
                {
                    break;
                }
                

                switch (number){
                    case 1:
                        data = employeeParser.SortingDirectSubordination(names.Result);
                        break;
                    case 2:
                        data = employeeParser.SearchPosition(names.Result, "Робітник");
                        break;
                    case 3:
                        data = employeeParser.SortingPosition(names.Result);
                        break;
                    case 4:
                        data = new List<string> { employeeParser.MaxSalary(names.Result)};
                        break;
                    case 5:
                        data = employeeParser.OverSalary(names.Result, 4000);
                        break;
                }

                foreach (var d in data)
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("\n");
            }


            M.Employees employees = new Employees(supplyManager);

            List<M.Interface.IEmployee> test = employees.Subordinate();

            foreach (var d in test)
            {
                Console.WriteLine(d.Name);
            }

            Console.Read();

        }

    }
}
