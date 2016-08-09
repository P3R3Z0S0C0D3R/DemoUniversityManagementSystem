using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        GetAllTables getAllTables = new GetAllTables();
        StudentManager studentManager=new StudentManager();
        public ActionResult StudentEntry()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult StudentEntry(Student student)
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            Department department = getAllTables.GetAllDepartments().FirstOrDefault(a => a.DepartmentId == student.StudentDepartmentId);
            if (department != null) student.StudentDepartmentCode = department.DepartmentCode;
            List<Student> allStudents = getAllTables.GetAllStudents();
            List<Student> studentList = allStudents.Where(a => a.StudentDepartmentId == student.StudentDepartmentId && a.StudentRegDate.Year.Equals(student.StudentRegDate.Year)).ToList();
            int rollNo = studentList.Count;
            if (rollNo > 0)
            {
                rollNo++;
                student.StudentRegistrationNo = student.StudentDepartmentCode + "-" + student.StudentRegDate.Year + "-" + rollNo.ToString("000");
            }
            else
            {
                student.StudentRegistrationNo = student.StudentDepartmentCode + "-" + student.StudentRegDate.Year + "-" + 1.ToString("000");
            }
            ViewBag.Message = studentManager.SaveStudent(student) ? "Student Saved Successfully.<br/>Student's Registration No: "+student.StudentRegistrationNo : "Student Save Failed";
            return View();
        }

        public ActionResult EnrollCourse()
        {
            ViewBag.StudentsList = getAllTables.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse enrollCourse)
        {
            Course course = getAllTables.GetAllCourses().FirstOrDefault(a => a.CourseId == enrollCourse.EnrollCourseCourseId);
            enrollCourse.EnrollCourseCourseCode = course.CourseCode;
            enrollCourse.EnrollCourseCourseName = course.CourseName;
            List<EnrollCourse> courseStatuses = getAllTables.GetAllEnrolledCourses().Where(a => a.EnrollCourseStudentId == enrollCourse.EnrollCourseStudentId && a.EnrollCourseCourseId == enrollCourse.EnrollCourseId).ToList();
            if (courseStatuses.Count == 0)
            {
                ViewBag.Message = studentManager.EnrollCourse(enrollCourse) ? "Course Enrolled Successfully" : "Course Enroll Failed";
            }
            ViewBag.StudentsList = getAllTables.GetAllStudents();
            return View();
        }
        public JsonResult IsEmailExists(FormCollection form)
        {
            string studentEmail = form["studentEmail"];
            List<Student> student = getAllTables.GetAllStudents().Where(a => a.StudentEmail == studentEmail).ToList();
            if (student.Count>0) return Json(false);
            return Json(true);
        }
        public JsonResult GetStudentDetails(int studentId)
        {
            Student student = getAllTables.GetAllStudents().FirstOrDefault(a => a.StudentId == studentId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> coursesList = getAllTables.GetAllCourses().Where(a => a.CourseDepartmentId == departmentId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsCourseEnrolled(int studentId,int courseId)
        {
            List<EnrollCourse> courseStatuses = getAllTables.GetAllEnrolledCourses().Where(a => a.EnrollCourseStudentId == studentId && a.EnrollCourseCourseId == courseId).ToList();
            if (courseStatuses.Count > 0) return Json(false);
            return Json(true);
        }
    }
}