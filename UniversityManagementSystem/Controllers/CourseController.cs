using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager=new CourseManager();
        //DepartmentManager departmentManager=new DepartmentManager();
        GetAllTables getAllTables=new GetAllTables();
        public ActionResult CourseEntry()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            ViewBag.SemesterList = getAllTables.GetAllSemesters();
            return View();
        }

        [HttpPost]
        public ActionResult CourseEntry(Course course)
        {
            if (ModelState.IsValid)
            {
                //if (!courseManager.IsCourseCodeExists(course.CourseCode) && !courseManager.IsCourseNameExists(course.CourseName))
                //{
                    ViewBag.Message = courseManager.SaveCourse(course) ? "Course Saved Successfully" : "Course Save Failed";
                //}
                ViewBag.DepartmentList = getAllTables.GetAllDepartments();
                ViewBag.SemesterList = getAllTables.GetAllSemesters();
            }
            else
            {
                ViewBag.DepartmentList = getAllTables.GetAllDepartments();
                ViewBag.SemesterList = getAllTables.GetAllSemesters();
            }
            return View();
        }
        public ActionResult CourseStatics()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            return View();
        }
        public JsonResult IsCourseCodeExists(FormCollection form)
        {
            string courseCode = form["courseCode"];
            List<Course> courses = getAllTables.GetAllCourses().Where(a => a.CourseCode == courseCode).ToList();
            if (courses.Count>0) return Json(false);
            return Json(true);
        }
        public JsonResult IsCourseNameExists(FormCollection form)
        {
            string courseName = form["courseName"];
            List<Course> courses = getAllTables.GetAllCourses().Where(a => a.CourseName == courseName).ToList();
            if (courses.Count>0) return Json(false);
            return Json(true);
        }
        public JsonResult GetCourseStatusByDepartmentId(int departmentId)
        {
            List<CourseStatus> courseStatusList = getAllTables.GetAllCourseStatus().Where(a => a.CourseStatusDepartmentId == departmentId).ToList();
            if (courseStatusList.Count == 0)
            {
                string flag = "";
                return Json(flag, JsonRequestBehavior.AllowGet);
            }
            return Json(courseStatusList, JsonRequestBehavior.AllowGet);
        }
    }
}