using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class ClassScheduleManager
    {
        ClassScheduleGateway classScheduleGateway=new ClassScheduleGateway();
        public void SaveClassSchedule(Course course)
        {
            classScheduleGateway.SaveClassSchedule(course);
        }
        public bool UpdateClassSchedul(ClassSchedule classSchedule)
        {
            return classScheduleGateway.UpdateClassSchedul(classSchedule) > 0;
        }
        public ClassSchedule GetClassScheduleByCourseCode(string courseCode)
        {
            return classScheduleGateway.GetClassScheduleByCourseCode(courseCode);
        }

        public List<ClassSchedule> GetAllClassSchedule()
        {
            return classScheduleGateway.GetAllClassSchedule();
        }
    }
}