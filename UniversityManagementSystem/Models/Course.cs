using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Provide Course Code")]
        [Remote("IsCourseCodeExists", "Course", ErrorMessage = "This Course Code Is Already Taken! Try Another.")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Please Provide Course Name")]
        [Remote("IsCourseNameExists", "Course", ErrorMessage = "This Course Name Is Already Taken! Try Another.")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please Provide Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Provide Course Credit Beetween 0.5 To 5.0")]
        public double CourseCredit { get; set; }
        [Required(ErrorMessage = "Please Provide Course Description")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int CourseDepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Semester")]
        public int CourseSemesterId { get; set; }
    }
}