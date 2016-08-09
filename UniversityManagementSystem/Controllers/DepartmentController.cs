using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        GetAllTables getAllTables=new GetAllTables();
        public ActionResult DepartmentEntry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentEntry(Department department)
        {
            //if (!departmentManager.IsDepartmentCodeExists(department.DepartmentCode) && !departmentManager.IsDepartmentNameExists(department.DepartmentName))
            //{
                
            //}
            ViewBag.Message = departmentManager.SaveDepartment(department) ? "Department Save Successfully" : "Department Save Failed";
            return View();
        }
        public ActionResult ViewDepartments()
        {
            ViewBag.Departments = getAllTables.GetAllDepartments();
            return View();
        }
        public JsonResult IsDepartmentCodeExists(FormCollection form)
        {
            string code = form["departmentCode"];
            List<Department> departments = getAllTables.GetAllDepartments().Where(a => a.DepartmentCode == code).ToList();
            if (departments.Count>0) return Json(false);
            return Json(true);
        }
        public JsonResult IsDepartmentNameExists(FormCollection form)
        {
            string name = form["departmentName"];
            List<Department> departments = getAllTables.GetAllDepartments().Where(a => a.DepartmentName == name).ToList();
            if (departments.Count > 0) return Json(false);
            return Json(true);
        }
    }
}