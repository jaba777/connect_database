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
            PKG_EMP package = new PKG_EMP();
            Employee employee = new Employee();
            bool isStart = true;
           
            while (isStart)
            {
                Console.WriteLine("Choose Operations: A-Add, U-update,D-Delete, G-Get");
                string operation = Console.ReadLine().ToLower();
                if (operation == "a")
                {
                    Console.WriteLine("write Name");
                    employee.Name = Console.ReadLine();
                    Console.WriteLine("write LastName");
                    employee.LastName = Console.ReadLine();
                    Console.WriteLine("write Position");
                    employee.Position = Console.ReadLine();

                    package.Save_Employee(employee);
                    isStart=false;
                }
                else if (operation == "u")
                {
                    int userId;

                    while (true)
                    {
                        Console.WriteLine("write User Id");

                        string input = Console.ReadLine();

                        if (int.TryParse(input, out userId))
                        {
                            employee.ID = userId;

                            Console.WriteLine("write Name");
                            employee.Name = Console.ReadLine();
                            Console.WriteLine("write LastName");
                            employee.LastName = Console.ReadLine();
                            Console.WriteLine("write Position");
                            employee.Position = Console.ReadLine();
                            package.Update_Employee(employee);
                            isStart = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");

                        }
                    }
                
                  

                }
                else if (operation == "d")
                {
                    int userId;

                    while (true)
                    {
                        Console.WriteLine("write User Id");

                        string input = Console.ReadLine();

                        if (int.TryParse(input, out userId))
                        {
                            employee.ID = userId;

                            package.Delete_Employee(userId);
                           
                            isStart = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");

                        }
                    }
                }
                else if (operation == "g")
                {
                    List<Employee> employees = package.GetEmployee();

                    foreach (Employee employe in employees)
                    {
                        Console.WriteLine(employe.Name);
                    }
                    isStart = false;
                }
                else
                {
                    Console.WriteLine("invalid symbol");
                }

            }




          


        }
    }
}
