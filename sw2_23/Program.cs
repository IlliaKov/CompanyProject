using M;
using M.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw2_23
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

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

            List<IEmployee> list = new List<IEmployee> { director, supplyManager, salesManager, workderB, workderA, workderX, workderY };





            IEmployee employee = director;


            var names = new GetNames();

            employee.Accept(names);

            EmployeeParser employeeParser = new EmployeeParser();
            

            while (true)
            {
                Console.WriteLine("1. Сортировка по належності (у вигляді дерева)\n2. Пошук позиції\n3. Сортировка по позиції\n4. Пошук більної зарплати\n5. Пошук більної заплати ніж у\n0. Вийти\n");
                int number = Convert.ToInt32(Console.ReadLine());

                Console.Clear();//clears a command menu

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
                        // Now you can enter employee position
                        Console.WriteLine("enter employee's position: ");
                        var result = Console.ReadLine();
                        data = employeeParser.SearchPosition(names.Result, result);
                        //
                        break;
                    case 3:
                        data = employeeParser.SortingPosition(names.Result);
                        break;
                    case 4:
                        data = new List<string> { employeeParser.MaxSalary(names.Result)};
                        break;
                    case 5:
                        // now you can enter salary
                        Console.WriteLine("enter salary you want to compare");
                        var result2 = Convert.ToInt32(Console.ReadLine());
                        data = employeeParser.OverSalary(names.Result, result2);
                        break;

                        // adding a new employee - new command
                    case 6:
                        Console.WriteLine("Choose employee's name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Choose employee's position: 1 - director, 2 - manager, 3 - worker");
                        var chos = Convert.ToInt32(Console.ReadLine());

                        List<string> resultNames = new List<string>();

                        IEmployee emp = null;
                        if (chos == 1)
                        {
                            emp = new Director(name, 5000);

                        }
                        else if (chos == 2)
                        {
                            emp = new Manager(name, 3000);
                            resultNames = employeeParser.SearchPosition(names.Result, "Director");
                        }
                        else if (chos == 3)
                        {
                            emp = new Worker(name, 1000);
                            resultNames = employeeParser.SearchPosition(names.Result, "Manager");
                        }

                        for (int i = 0; i < resultNames.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} {resultNames[i]}");
                        }

                        var empNum = Convert.ToInt32(Console.ReadLine());
                        list.Add(emp);
                        var iemp = list.Find(x => x.Name == resultNames[empNum - 1]);
                        iemp.Add(emp);

                        names = new GetNames();
                        employee.Accept(names);

                        break;
                }

                foreach (var d in data)
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("\n");
            }


            Employees employees = new Employees(supplyManager);

            List<M.Interface.IEmployee> test = employees.Subordinate();

            foreach (var d in test)
            {
                Console.WriteLine(d.Name);
            }

            Console.Read();

        }

    }
}
