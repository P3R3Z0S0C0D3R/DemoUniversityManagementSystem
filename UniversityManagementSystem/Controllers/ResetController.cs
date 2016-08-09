using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.Controllers
{
    public class ResetController : Controller
    {
        ArchiveManager archiveManager=new ArchiveManager();
        ResetAllManager resetAllManager = new ResetAllManager();
        TeacherManager teacherManager = new TeacherManager();
        public ActionResult ResetCourses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetCourses(string confirMation)
        {
            if (HttpContext.Request.IsAjaxRequest())
            {
                string message = archiveManager.UnassignAllCourses() && resetAllManager.UnassignAllCourses() && teacherManager.UpdateAllTeacher() ? "All Courses Unassigned Successfully" : "Course Unassigning Process Failed"; ;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult ResetClassrooms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetClassrooms(string confirMation)
        {
            if (HttpContext.Request.IsAjaxRequest())
            {
                string message = archiveManager.UnallocateAllClassrooms() && resetAllManager.UnallocateAllClassrooms() && teacherManager.UpdateAllTeacher() ? "All Classrooms Unallocated Successfully" : "Classroom Unallocation Process Failed"; ;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}