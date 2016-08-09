using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AssignCourse
    {
        public int AssignCourseDepartmentId { get; set; }
        public int AssignCourseTeacherId { get; set; }
        public int AssignCourseCourseId { get; set; }
    }
}