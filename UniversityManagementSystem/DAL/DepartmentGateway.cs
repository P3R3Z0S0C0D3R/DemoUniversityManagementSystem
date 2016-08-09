using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class DepartmentGateway:CommonGateway
    {
        public int SaveDepartment(Department department)
        {
            Query = "INSERT INTO Departments(DepartmentCode,DepartmentName) VALUES(@DepartmentCode,@DepartmentName)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("DepartmentCode", SqlDbType.VarChar);
            Command.Parameters["DepartmentCode"].Value = department.DepartmentCode;
            Command.Parameters.Add("DepartmentName", SqlDbType.VarChar);
            Command.Parameters["DepartmentName"].Value = department.DepartmentName;
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Department> GetAllDepartments()
        {
            Query = "SELECT *FROM Departments ORDER BY DepartmentName ASC";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                    department.DepartmentCode = reader["DepartmentCode"].ToString();
                    department.DepartmentName = reader["DepartmentName"].ToString();
                    departments.Add(department);
                }
                reader.Close();
            }
            Connection.Close();
            return departments;
        }
    }
}