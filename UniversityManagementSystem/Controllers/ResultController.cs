using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        GetAllTables getAllTables=new GetAllTables();
        ResultManager resultManager=new ResultManager();
        public ActionResult StudentResultEntry()
        {
            ViewBag.StudentsList = getAllTables.GetAllStudents();
            ViewBag.GradesList = getAllTables.GetAllGrades();
            return View();
        }
        [HttpPost]
        public ActionResult StudentResultEntry(Result result)
        {
            Course course = getAllTables.GetAllCourses().FirstOrDefault(a => a.CourseId == result.ResultStudentCourseId);
            result.ResultStudentCourseCode = course.CourseCode;
            result.ResultStudentCourseName = course.CourseName;
            Grade grade = getAllTables.GetAllGrades().FirstOrDefault(a => a.GradeId == result.ResultGradeId);
            result.ResultGradeName = grade.GradeName;
            ViewBag.Message = resultManager.SaveStudentResult(result) ? "Result Saved Successfully" : "Result Save Failed";
            ViewBag.StudentsList = getAllTables.GetAllStudents();
            ViewBag.GradesList = getAllTables.GetAllGrades();
            return View();
        }
        public ActionResult ViewStudentResult()
        {
            ViewBag.StudentsList = getAllTables.GetAllStudents();
            return View();
        }
        public JsonResult GetStudentDetails(int studentId)
        {
            Student student = getAllTables.GetAllStudents().FirstOrDefault(a => a.StudentId == studentId);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllEnrolledCourses(int studentId)
        {
            List<EnrollCourse> enrolledCourses = getAllTables.GetAllEnrolledCourses().Where(a => a.EnrollCourseStudentId == studentId).ToList();
            return Json(enrolledCourses, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsResultAdded(int studentId, int courseId)
        {
            List<Result> courseStatuses = getAllTables.GetStudentResult().Where(a => a.ResultStudentId == studentId && a.ResultStudentCourseId == courseId).ToList();
            if (courseStatuses.Count > 0) return Json(false);
            return Json(true);
        }
        public JsonResult GetStudentResult(int studentId)
        {
            List<Result> studentResult = getAllTables.GetStudentResult().Where(a => a.ResultStudentId == studentId).ToList();
            if (studentResult.Count == 0)
            {
                string flag = "";
                return Json(flag, JsonRequestBehavior.AllowGet);
            }
            return Json(studentResult, JsonRequestBehavior.AllowGet);
        }
    }
}