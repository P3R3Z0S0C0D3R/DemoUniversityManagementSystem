using System.Collections.Generic;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();
        ClassScheduleManager classScheduleManager=new ClassScheduleManager();
        //public bool IsCourseCodeExists(string courseCode)
        //{
        //    return courseGateway.IsCourseCodeExists(courseCode);
        //}

        //public bool IsCourseNameExists(string courseName)
        //{
        //    return courseGateway.IsCourseNameExists(courseName);
        //}
        public List<Semester> GetAllSemesters()
        {
            return courseGateway.GetAllSemesters();
        }
        public bool SaveCourse(Course course)
        {
            courseGateway.SaveCourseStatus(course);
            classScheduleManager.SaveClassSchedule(course);
            return courseGateway.SaveCourse(course) > 0;
        }
		public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }
        //public Course GetCourseDetails(int courseId)
        //{
        //    return courseGateway.GetCourseDetails(courseId);
        //}

        public List<CourseStatus> GetAllCoursesStatus()
        {
            return courseGateway.GetAllCoursesStatus();
        }
    }
}