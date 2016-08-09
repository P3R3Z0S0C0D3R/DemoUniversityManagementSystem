using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ClassSchedule
    {
        public int ClassScheduleId { get; set; }
        public int ClassScheduleDepartmentId { get; set; }
        public string ClassScheduleCourseCode { get; set; }
        public string ClassScheduleCourseName { get; set; }
        public string ClassScheduleInfo { get; set; }
    }
}