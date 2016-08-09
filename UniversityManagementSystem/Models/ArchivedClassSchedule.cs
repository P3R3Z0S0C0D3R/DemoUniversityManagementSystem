using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ArchivedClassSchedule
    {
        public int ArchivedClassScheduleId { get; set; }
        public int ClassScheduleDepartmentId { get; set; }
        public string ClassScheduleCourseCode { get; set; }
        public string ClassScheduleCourseName { get; set; }
        public string ClassScheduleInfo { get; set; }
    }
}