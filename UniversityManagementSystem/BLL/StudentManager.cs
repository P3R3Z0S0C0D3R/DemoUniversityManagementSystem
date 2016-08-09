using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway=new StudentGateway();
        //public bool IsEmailExists(string studentEmail)
        //{
        //    return studentGateway.IsEmailExists(studentEmail);
        //}
        public bool SaveStudent(Student student)
        {
            return studentGateway.SaveStudent(student) > 0;
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }

        public bool EnrollCourse(EnrollCourse enrollCourse)
        {
            return studentGateway.EnrollCourse(enrollCourse) > 0;
        }

        public List<EnrollCourse> GetAllEnrolledCourses()
        {
            return studentGateway.GetAllEnrolledCourses();
        }
    }
}