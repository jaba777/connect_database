using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NpgsqlTypes;
using database.Packages;
using database.Models;

namespace database
{
    internal class Program
    {
        static void Main(string[] args)
        {//add employee
         //PKG_EMP package = new PKG_EMP();
         //Employee employee = new Employee();
         //employee.Name = Console.ReadLine();
         //employee.LastName = Console.ReadLine();
         //employee.Position = Console.ReadLine();

            //package.Save_Employee(employee);

            //Update Employee
            //PKG_EMP package = new PKG_EMP();
            //Employee employee = new Employee();
            //employee.ID = int.Parse(Console.ReadLine());
            //employee.Name = Console.ReadLine();
            //employee.LastName = Console.ReadLine();
            //employee.Position = Console.ReadLine();
            //package.Update_Employee(employee);

            //Delete Employee

            //PKG_EMP package = new PKG_EMP();
            //Employee employee = new Employee();
            //int employeeId = int.Parse(Console.ReadLine());

            //package.Delete_Employee(employeeId);

            PKG_EMP package = new PKG_EMP();
            List<Employee> employees = package.GetEmployee();

            foreach (Employee employee in employees) { 
            Console.WriteLine(employee.Name);
            }


        }
    }
}
