using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.DynamicData;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class CourseGateway:CommonGateway
    {
        //public bool IsCourseCodeExists(string courseCode)
        //{
        //    Query = "SELECT * FROM Courses WHERE CourseCode = '" + courseCode + "'";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    bool isCourseCodeExists = reader.HasRows;
        //    Connection.Close();
        //    return isCourseCodeExists;
        //}
        //public bool IsCourseNameExists(string courseName)
        //{
        //    Query = "SELECT * FROM Courses WHERE CourseName = '" + courseName + "'";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    bool isCourseNameExists = reader.HasRows;
        //    Connection.Close();
        //    return isCourseNameExists;
        //}
        public int SaveCourse(Course course)
        {
            Query = "INSERT INTO Courses(CourseCode,CourseName,CourseCredit,CourseDescription,CourseDepartmentId,CourseSemesterId) VALUES(@CourseCode,@CourseName,@CourseCredit,@CourseDescription,@CourseDepartmentId,@CourseSemesterId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseCode"].Value = course.CourseCode;
            Command.Parameters.Add("CourseName", SqlDbType.VarChar);
            Command.Parameters["CourseName"].Value = course.CourseName;
            Command.Parameters.Add("CourseCredit", SqlDbType.Decimal);
            Command.Parameters["CourseCredit"].Value = course.CourseCredit;
            Command.Parameters.Add("CourseDescription", SqlDbType.VarChar);
            Command.Parameters["CourseDescription"].Value = course.CourseDescription;
            Command.Parameters.Add("CourseDepartmentId", SqlDbType.Int);
            Command.Parameters["CourseDepartmentId"].Value = course.CourseDepartmentId;
            Command.Parameters.Add("CourseSemesterId", SqlDbType.Int);
            Command.Parameters["CourseSemesterId"].Value = course.CourseSemesterId;
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public List<Course> GetAllCourses()
        {
            Query = "SELECT *FROM Courses ORDER BY CourseCode ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseId = int.Parse(reader["CourseId"].ToString());
                    course.CourseCode = reader["CourseCode"].ToString();
                    course.CourseName = reader["CourseName"].ToString();
                    course.CourseCredit = double.Parse(reader["CourseCredit"].ToString());
                    course.CourseDescription = reader["CourseDescription"].ToString();
                    course.CourseDepartmentId = int.Parse(reader["CourseDepartmentId"].ToString());
                    course.CourseSemesterId = int.Parse(reader["CourseSemesterId"].ToString());
                    courses.Add(course);
                }
                reader.Close();
            }
            Connection.Close();
            return courses;
        }
        //public Course GetCourseDetails(int courseId)
        //{
        //    Query = "SELECT *FROM Courses WHERE CourseId="+courseId;
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    Course course = new Course();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            course.CourseId = int.Parse(reader["CourseId"].ToString());
        //            course.CourseCode = reader["CourseCode"].ToString();
        //            course.CourseName = reader["CourseName"].ToString();
        //            course.CourseCredit = double.Parse(reader["CourseCredit"].ToString());
        //            course.CourseDescription = reader["CourseDescription"].ToString();
        //            course.CourseDepartmentId = int.Parse(reader["CourseDepartmentId"].ToString());
        //            course.CourseSemesterId = int.Parse(reader["CourseSemesterId"].ToString());
        //        }
        //        reader.Close();
        //    }
        //    Connection.Close();
        //    return course;
        //}
        public List<Semester> GetAllSemesters()
        {
            Query = "SELECT * FROM Semesters";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semester semester = new Semester();
                    semester.SemesterId = int.Parse(reader["SemesterId"].ToString());
                    semester.SemesterName = reader["SemesterName"].ToString();
                    semesters.Add(semester);
                }
                reader.Close();
            }
            Connection.Close();
            return semesters;
        }
        public void SaveCourseStatus(Course course)
        {
            string semName = null;
            if (course.CourseSemesterId == 1) semName = "1st";
            else if (course.CourseSemesterId == 2) semName = "2nd";
            else if (course.CourseSemesterId == 3) semName = "3rd";
            else semName = course.CourseSemesterId + "th";
            Query = "INSERT INTO CourseStatics(CourseStatusDepartmentId,CourseStatusCourseCode,CourseStatusCourseName,CourseStatusSemesterName,CourseStatusIsAssigned) VALUES(@CourseStatusDepartmentId,@CourseStatusCourseCode,@CourseStatusCourseName,@CourseStatusSemesterName,@CourseStatusIsAssigned)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("CourseStatusDepartmentId", SqlDbType.Int);
            Command.Parameters["CourseStatusDepartmentId"].Value = course.CourseDepartmentId;
            Command.Parameters.Add("CourseStatusCourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseStatusCourseCode"].Value = course.CourseCode;
            Command.Parameters.Add("CourseStatusCourseName", SqlDbType.VarChar);
            Command.Parameters["CourseStatusCourseName"].Value = course.CourseName;
            Command.Parameters.Add("CourseStatusSemesterName", SqlDbType.VarChar);
            Command.Parameters["CourseStatusSemesterName"].Value = semName;
            Command.Parameters.Add("CourseStatusIsAssigned", SqlDbType.VarChar);
            Command.Parameters["CourseStatusIsAssigned"].Value = "NO";
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public List<CourseStatus> GetAllCoursesStatus()
        {
            Query = "SELECT *FROM CourseStatics ORDER BY CourseStatusCourseCode ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<CourseStatus> courseStatics = new List<CourseStatus>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CourseStatus courseStatus = new CourseStatus();
                    courseStatus.CourseStatusId = int.Parse(reader["CourseStatusId"].ToString());
                    courseStatus.CourseStatusDepartmentId = int.Parse(reader["CourseStatusDepartmentId"].ToString());
                    courseStatus.CourseStatusCourseCode = reader["CourseStatusCourseCode"].ToString();
                    courseStatus.CourseStatusCourseName = reader["CourseStatusCourseName"].ToString();
                    courseStatus.CourseStatusSemesterName = reader["CourseStatusSemesterName"].ToString();
                    courseStatus.CourseStatusTeacherName = reader["CourseStatusTeacherName"].ToString() != "" ? reader["CourseStatusTeacherName"].ToString() : "Not Assigned Yet";
                    courseStatus.CourseStatusIsAssigned = reader["CourseStatusIsAssigned"].ToString();
                    courseStatics.Add(courseStatus);
                }
                reader.Close();
            }
            Connection.Close();
            return courseStatics;
        }
    }
}