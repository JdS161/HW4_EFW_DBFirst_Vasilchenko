using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW4_EFW_DBFirst_Vasilchenko.DataLayer;
using HW4_EFW_DBFirst_Vasilchenko.Model;

namespace HW4_EFW_DBFirst_Vasilchenko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. SELECT All
            var db = new CompanyDBEntities();
            //Console.WriteLine("----------------SELECT ALL EMPLOYEES----------------");
            //IEnumerable<EmployeeModel> empls = DL.All();
            //foreach (var empl in empls)
            //{
            //    Console.WriteLine($"{empl.EmployeeID}\t{empl.LastName}\t\t{empl.FirstName}\t{empl.BirthDate}");
            //}

            Console.WriteLine("\n----------------SELECT EMPLOYEE ByID----------------");
            //EmployeeModel employeeModel = DL.ByID(10);
            //Console.WriteLine($"{employeeModel.EmployeeID}\t{employeeModel.LastName}\t\t{employeeModel.FirstName}\t{employeeModel.BirthDate}");

            Console.WriteLine("\n--------------------ADD EMPLOYEE--------------------");
            //EmployeeModel newEmployee = new EmployeeModel()
            //{ 
            //    FirstName = "Barbara",
            //    LastName = "Straizend",
            //    BirthDate = new DateTime(1964 - 12 - 03),
            //    PositionID = 2            
            //};
            //newEmployee.EmployeeID = DL.Add(newEmployee);
            //Console.WriteLine($"{newEmployee.EmployeeID}");

            Console.WriteLine("\n------------------DELETE EMPLOYEE------------------");
            //DL.Delete(14);

            Console.WriteLine("\n------------------UPDATE EMPLOYEE------------------");

            EmployeeModel employee = new EmployeeModel()
            {
                FirstName = "Kurtz",
                LastName = "Neu",
                BirthDate = new DateTime(2000, 10, 10),
                EmployeeID = 13,
                PositionID = 2,
            };

            DL.Update_Empl(employee);






            Console.ReadKey();
        }
    }
}
