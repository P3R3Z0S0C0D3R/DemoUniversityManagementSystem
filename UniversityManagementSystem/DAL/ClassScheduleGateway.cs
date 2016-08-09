using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class ClassScheduleGateway:CommonGateway
    {
        public void SaveClassSchedule(Course course)
        {
            Query = "INSERT INTO ClassSchedules(ClassScheduleCourseCode,ClassScheduleCourseName,ClassScheduleDepartmentId) VALUES(@ClassScheduleCourseCode,@ClassScheduleCourseName,@ClassScheduleDepartmentId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("ClassScheduleDepartmentId", SqlDbType.Int);
            Command.Parameters["ClassScheduleDepartmentId"].Value = course.CourseDepartmentId;
            Command.Parameters.Add("ClassScheduleCourseCode", SqlDbType.VarChar);
            Command.Parameters["ClassScheduleCourseCode"].Value = course.CourseCode;
            Command.Parameters.Add("ClassScheduleCourseName", SqlDbType.VarChar);
            Command.Parameters["ClassScheduleCourseName"].Value = course.CourseName;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public ClassSchedule GetClassScheduleByCourseCode(string courseCode)
        {
            Query = "SELECT *FROM ClassSchedules WHERE ClassScheduleCourseCode='" + courseCode + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            ClassSchedule classSchedule = new ClassSchedule();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classSchedule.ClassScheduleId = int.Parse(reader["ClassScheduleId"].ToString());
                    classSchedule.ClassScheduleCourseCode = reader["ClassScheduleCourseCode"].ToString();
                    classSchedule.ClassScheduleCourseName = reader["ClassScheduleCourseName"].ToString();
                    classSchedule.ClassScheduleInfo = reader["ClassScheduleInfo"].ToString();
                }
                reader.Close();
            }
            Connection.Close();
            return classSchedule;
        }
        public int UpdateClassSchedul(ClassSchedule classSchedule)
        {
            Query = "UPDATE ClassSchedules SET ClassScheduleInfo='" + classSchedule.ClassScheduleInfo + "'" + " WHERE ClassScheduleCourseCode='" + classSchedule.ClassScheduleCourseCode + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<ClassSchedule> GetAllClassSchedule()
        {
            Query = "SELECT *FROM ClassSchedules";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<ClassSchedule> classSchedules=new List<ClassSchedule>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassSchedule classSchedule = new ClassSchedule();
                    classSchedule.ClassScheduleId = int.Parse(reader["ClassScheduleId"].ToString());
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