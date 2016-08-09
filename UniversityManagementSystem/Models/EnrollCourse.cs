using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class EnrollCourse
    {
        public int EnrollCourseId { get; set; }
        public int EnrollCourseStudentId { get; set; }
        public int EnrollCourseCourseId { get; set; }
        public string EnrollCourseCourseCode { get; set; }
		public string EnrollCourseCourseName { get; set; }
        public DateTime EnrollCourseDate { get; set; }

    }
}