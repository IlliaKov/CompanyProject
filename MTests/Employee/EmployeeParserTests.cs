using Microsoft.VisualStudio.TestTools.UnitTesting;
using M;
using System;
using System.Collections.Generic;
using System.Text;

namespace M.Tests
{
    [TestClass()]
    public class EmployeeParserTests
    {
        [TestMethod()]
        public void MaxSalaryTest()
        {
            const string Expected = "andriy";
            var director = new Director(Expected, 12000);
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
            string result = employeeParser.MaxSalary(names.Result);

            

            Assert.AreEqual(Expected, result);
        }
    }
}