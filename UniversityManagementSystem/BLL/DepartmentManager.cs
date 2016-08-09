using System.Collections.Generic;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();

        //public bool IsDepartmentCodeExists(string departmentCode)
        //{
        //    return departmentGateway.IsDepartmentCodeExists(departmentCode);
        //}
        //public bool IsDepartmentNameExists(string departmentName)
        //{
        //    return departmentGateway.IsDepartmentNameExists(departmentName);
        //}
        public bool SaveDepartment(Department department)
        {
            return departmentGateway.SaveDepartment(department) > 0;
        }
        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }
    }
}