using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.Models
{
    public class GetAllTables
    {
        AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();
        ArchiveManager archiveManager=new ArchiveManager();
        ClassScheduleManager classScheduleManager = new ClassScheduleManager();
        CourseManager courseManager = new CourseManager();
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager=new StudentManager();
        TeacherManager teacherManager = new TeacherManager();
        ResultManager resultManager=new ResultManager();
        public List<Day> GetAllDays()
        {
            return allocateClassroomManager.GetAllDays();
        }
        public List<Room> GetAllRooms()
        {
            return allocateClassroomManager.GetAllRooms();
        }
        public List<Department> GetAllDepartments()
        {
            return departmentManager.GetAllDepartments();
        }
        public List<Course> GetAllCourses()
        {
            return courseManager.GetAllCourses();
        }
        public List<ClassSchedule> GetAllClassSchedule()
        {
            return classScheduleManager.GetAllClassSchedule();
        }
        public List<ArchivedClassSchedule> GetAllArchivedClassSchedules()
        {
            return archiveManager.GetAllArchivedClassSchedules();
        }
        public List<ArchivedCourseStatus> GetAllArchivedCourseStatuses()
        {
            return archiveManager.GetAllArchivedCourseStatus();
        }
        public List<Student> GetAllStudents()
        {
            return studentManager.GetAllStudents();
        }
        public List<Teacher> GetAllTeachers()
        {
            return teacherManager.GetAllTeachers();
        }
        public List<Designation> GetAllDesignations()
        {
            return teacherManager.GetAllDesignations();
        }
        public List<CourseStatus> GetAllCourseStatus()
        {
            return courseManager.GetAllCoursesStatus();
        }
        public List<Semester> GetAllSemesters()
        {
            return courseManager.GetAllSemesters();
        }
        public List<AllocateClassroom> GetAllAllocationInfo()
        {
            return allocateClassroomManager.GetAllAllocationInfo();
        }
        public List<EnrollCourse> GetAllEnrolledCourses()
        {
            return studentManager.GetAllEnrolledCourses();
        }

        public List<Grade> GetAllGrades()
        {
            return resultManager.GetAllGrades();
        }

        public List<Result> GetStudentResult()
        {
            return resultManager.GetStudentResult();
        }
    }
}