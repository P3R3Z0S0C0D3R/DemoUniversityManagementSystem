using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        GetAllTables getAllTables=new GetAllTables();
        TeacherManager teacherManager = new TeacherManager();
        public ActionResult TeacherEntry()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            ViewBag.DesignationList = getAllTables.GetAllDesignations();
            return View();
        }
        [HttpPost]
        public ActionResult TeacherEntry(Teacher teacher)
        {
            List<Teacher> teachers = getAllTables.GetAllTeachers();
            List<Teacher> teacherWithEmail = teachers.Where(a => a.TeacherEmail == teacher.TeacherEmail).ToList();
            if (teacherWithEmail.Count == 0)
            {
                ViewBag.Message = teacherManager.SaveTeacher(teacher) ? "Teacher Saved Successfully" : "Teacher Save Failed";
            }
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            ViewBag.DesignationList = getAllTables.GetAllDesignations();
            return View();
        }

        public ActionResult AssignCourse()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult AssignCourse(AssignCourse assignCourse)
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            Teacher teacher = getAllTables.GetAllTeachers().FirstOrDefault(a => a.TeacherId == assignCourse.AssignCourseTeacherId);
            Course course = getAllTables.GetAllCourses().FirstOrDefault(a => a.CourseId == assignCourse.AssignCourseCourseId);
            teacher.RemainingCredit -= course.CourseCredit;
            if (HttpContext.Request.IsAjaxRequest())
            {
                string message = teacherManager.AssignCourse(teacher, course) ? "Course Assigned Successfully" : "Course Assign Failed";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            ViewBag.Message = teacherManager.AssignCourse(teacher, course) ? "Course Assigned Successfully" : "Course Assign Failed";
            return View();
        }
        public JsonResult IsEmailExists(Teacher teacher)
        {
            List<Teacher> teachers = getAllTables.GetAllTeachers();
            List<Teacher> teacherWithEmail = teachers.Where(a => a.TeacherEmail == teacher.TeacherEmail).ToList();
            if (teacherWithEmail.Count>0) return Json(false);
            return Json(true);
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = getAllTables.GetAllTeachers();
            List<Teacher> teachersList = teachers.Where(a => a.TeacherDepartmentId == departmentId).ToList();
            return Json(teachersList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> courses = getAllTables.GetAllCourses();
            List<Course> coursesList = courses.Where(a => a.CourseDepartmentId == departmentId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherDetails(int teacherId)
        {
            Teacher teacher = getAllTables.GetAllTeachers().FirstOrDefault(a => a.TeacherId == teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseDetails(int courseId)
        {
            Course course = getAllTables.GetAllCourses().FirstOrDefault(a => a.CourseId == courseId);
            return Json(course, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsCourseAssign(int courseId)
        {
            Course course = getAllTables.GetAllCourses().FirstOrDefault(a => a.CourseId == courseId);
            List<CourseStatus> courseStatuses = getAllTables.GetAllCourseStatus().Where(a => a.CourseStatusCourseCode == course.CourseCode && a.CourseStatusIsAssigned == "YES").ToList();
            if (courseStatuses.Count>0) return Json(false);
            return Json(true);
        }
    }
}