using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ArchivedCourseStatus
    {
        public int ArchivedCourseStatusId { get; set; }
        public int CourseStatusDepartmentId { get; set; }
        public string CourseStatusCourseCode { get; set; }
        public string CourseStatusCourseName { get; set; }
        public string CourseStatusSemesterName { get; set; }
        public string CourseStatusTeacherName { get; set; }
    }
}