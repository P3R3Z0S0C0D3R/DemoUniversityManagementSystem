using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ArchiveController : Controller
    {
        GetAllTables getAllTables=new GetAllTables();
        public ActionResult UnassignedCourses()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            return View();
        }
        public ActionResult UnallocatedClassSchedule()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            return View();
        }
        public JsonResult GetArchivedCourseStatusByDepartmentId(int departmentId)
        {
            var coursesStatus = getAllTables.GetAllArchivedCourseStatuses();
            var courseStatusList = coursesStatus.Where(a => a.CourseStatusDepartmentId == departmentId).ToList();
            if (courseStatusList.Count == 0)
            {
                string flag = "";
                return Json(flag, JsonRequestBehavior.AllowGet);
            }
            return Json(courseStatusList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetArchivedClassroomScheduleByDepartmentId(int departmentId)
        {
            var classSchedule = getAllTables.GetAllArchivedClassSchedules();
            var classScheduleList = classSchedule.Where(a => a.ClassScheduleDepartmentId == departmentId).ToList();
            if (classScheduleList.Count == 0)
            {
                string flag = "";
                return Json(flag, JsonRequestBehavior.AllowGet);
            }
            return Json(classScheduleList, JsonRequestBehavior.AllowGet);
        }
    }
}