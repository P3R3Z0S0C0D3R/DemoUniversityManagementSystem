using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int ResultStudentId { get; set; }
        public int ResultStudentCourseId { get; set; }
        public string ResultStudentCourseCode { get; set; }
        public string ResultStudentCourseName { get; set; }
        public int ResultGradeId { get; set; }
        public string ResultGradeName { get; set; }
    }
}