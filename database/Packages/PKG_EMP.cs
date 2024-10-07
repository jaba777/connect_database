using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NpgsqlTypes;
using database.Models;

namespace database.Packages
{
    internal class PKG_EMP
    {
        public string connectionString;
        public PKG_EMP() {
            this.connectionString = "Host=localhost; Port=5432; Database=new_base; Username=postgres; Password=jaba123";
        }

        
            public void Save_Employee(Employee employee)
            {
            
            var conn = new NpgsqlConnection();
            conn.ConnectionString = this.connectionString;
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO public.employee (first_name, last_name, position) VALUES (@FirstName, @LastName, @Position)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@FirstName", NpgsqlDbType.Varchar).Value = employee.Name;
            cmd.Parameters.Add("@LastName", NpgsqlDbType.Varchar).Value = employee.LastName;
            cmd.Parameters.Add("@Position", NpgsqlDbType.Varchar).Value = employee.Position;
            cmd.ExecuteNonQuery();

            conn.Close();

            }

        public void Update_Employee(Employee employee)
        {
            
            var conn = new NpgsqlConnection();
            conn.ConnectionString = this.connectionString;
            conn.Open();    
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE public.employee SET first_name = @FirstName, last_name = @LastName, position=@Position WHERE employee.id = @EmployeeId";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@FirstName",NpgsqlDbType.Varchar).Value=employee.Name;
            cmd.Parameters.Add("@LastName",NpgsqlDbType.Varchar).Value=employee.LastName;
            cmd.Parameters.Add("@Position",NpgsqlDbType.Varchar).Value=employee.Position;
            cmd.Parameters.Add("@EmployeeId", NpgsqlDbType.Integer).Value = employee.ID;
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void Delete_Employee(int employeeId) {
            
            var conn = new NpgsqlConnection();
            conn.ConnectionString = this.connectionString;
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM public.employee WHERE employee.id=@EmployeeId";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EmployeeId", NpgsqlDbType.Integer).Value = employeeId;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            var conn = new NpgsqlConnection();
            conn.ConnectionString = this.connectionString;
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM public.employee";
            cmd.CommandType = CommandType.Text;
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            while (reader.Read()) {
                Employee emp = new Employee();
                emp.ID = int.Parse(reader["id"].ToString());
                emp.Name = reader["first_name"].ToString();
                emp.Position = reader["position"].ToString();
                emp.LastName = reader["last_name"].ToString();
                employees.Add( emp );
            }
            //cmd.ExecuteNonQuery();
            conn.Close();
            return employees;
        }

    }
}
