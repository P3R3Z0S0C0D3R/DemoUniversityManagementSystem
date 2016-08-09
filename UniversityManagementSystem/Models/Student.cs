using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContactNo { get; set; }
        public DateTime StudentRegDate { get; set; }
        public string StudentAddress { get; set; }
        public int StudentDepartmentId { get; set; }
        public string StudentDepartmentCode { get; set; }
        public string StudentRegistrationNo { get; set; }
    }
}