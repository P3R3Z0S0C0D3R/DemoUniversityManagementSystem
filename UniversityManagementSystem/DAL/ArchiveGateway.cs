using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class ArchiveGateway:CommonGateway
    {
        public int UnassignAllCourses()
        {
            Query = "INSERT INTO ArchivedCourseStatics(CourseStatusDepartmentId,CourseStatusCourseCode,CourseStatusCourseName,CourseStatusSemesterName,CourseStatusTeacherName) SELECT CourseStatusDepartmentId,CourseStatusCourseCode,CourseStatusCourseName,CourseStatusSemesterName,CourseStatusTeacherName FROM CourseStatics WHERE NULLIF(CourseStatusTeacherName, '') IS NOT NULL";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public int UnallocateAllClassrooms()
        {
            Query = "INSERT INTO ArchivedClassSchedules(ClassScheduleCourseCode,ClassScheduleCourseName,ClassScheduleInfo,ClassScheduleDepartmentId) SELECT ClassScheduleCourseCode,ClassScheduleCourseName,ClassScheduleInfo,ClassScheduleDepartmentId FROM ClassSchedules WHERE NULLIF(ClassScheduleInfo, '') IS NOT NULL";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public List<ArchivedCourseStatus> GetAllArchivedCourseStatus()
        {
            Query = "SELECT *FROM ArchivedCourseStatics ORDER BY CourseStatusSemesterName ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<ArchivedCourseStatus> archivedCourseStatistics = new List<ArchivedCourseStatus>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ArchivedCourseStatus archivedCourseStatus = new ArchivedCourseStatus();
                    archivedCourseStatus.ArchivedCourseStatusId = int.Parse(reader["ArchivedCourseStatusId"].ToString());
                    archivedCourseStatus.CourseStatusDepartmentId = int.Parse(reader["CourseStatusDepartmentId"].ToString());
                    archivedCourseStatus.CourseStatusCourseCode = reader["CourseStatusCourseCode"].ToString();
                    archivedCourseStatus.CourseStatusCourseName = reader["CourseStatusCourseName"].ToString();
                    archivedCourseStatus.CourseStatusSemesterName = reader["CourseStatusSemesterName"].ToString();
                    archivedCourseStatus.CourseStatusTeacherName = reader["CourseStatusTeacherName"].ToString() != "" ? reader["CourseStatusTeacherName"].ToString() : "Not Assigned Yet";
                    archivedCourseStatistics.Add(archivedCourseStatus);
                }
                reader.Close();
            }
            Connection.Close();
            return archivedCourseStatistics;
        }
        public List<ArchivedClassSchedule> GetAllArchivedClassSchedules()
        {
            Query = "SELECT *FROM ArchivedClassSchedules";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<ArchivedClassSchedule> classSchedules = new List<ArchivedClassSchedule>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ArchivedClassSchedule classSchedule = new ArchivedClassSchedule();
                    classSchedule.ArchivedClassScheduleId = int.Parse(reader["ArchivedClassScheduleId"].ToString());
                    classSchedule.ClassScheduleDepartmentId = int.Parse(reader["ClassScheduleDepartmentId"].ToString());
                    classSchedule.ClassScheduleCourseCode = reader["ClassScheduleCourseCode"].ToString();
                    classSchedule.ClassScheduleCourseName = reader["ClassScheduleCourseName"].ToString();
                    classSchedule.ClassScheduleInfo = reader["ClassScheduleInfo"].ToString() != "" ? reader["ClassScheduleInfo"].ToString() : "Not Scheduled Yet";
                    classSchedules.Add(classSchedule);
                }
                reader.Close();
            }
            Connection.Close();
            return classSchedules;
        }
    }
}