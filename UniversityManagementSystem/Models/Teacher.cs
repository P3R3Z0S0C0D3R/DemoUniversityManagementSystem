using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherContactNo { get; set; }
        public int TeacherDesignationId { get; set; }
        public int TeacherDepartmentId { get; set; }
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
    }
}