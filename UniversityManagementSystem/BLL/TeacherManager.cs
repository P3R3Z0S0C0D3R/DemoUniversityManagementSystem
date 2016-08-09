using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        //public bool IsEmailExists(string teacherEmail)
        //{
        //    return teacherGateway.IsEmailExists(teacherEmail);
        //}
        public List<Designation> GetAllDesignations()
        {
            return teacherGateway.GetAllDesignations();
        }
        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeachers();
        }
        public bool SaveTeacher(Teacher teacher)
        {
            return teacherGateway.SaveTeacher(teacher) > 0;
        }
        //public Teacher GetTeacherDetails(int teacherId)
        //{
        //    return teacherGateway.GetTeacherDetails(teacherId);
        //}

        public bool AssignCourse(Teacher teacher, Course course)
        {
            return teacherGateway.AssignCourse(teacher, course) > 1;
        }
        public bool UpdateAllTeacher()
        {
            return teacherGateway.UpdateAllTeacher() > 0;
        }
        //public bool IsCourseAssign(string courseCode)
        //{
        //    return teacherGateway.IsCourseAssign(courseCode);
        //}
    }
}