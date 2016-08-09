using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class StudentGateway:CommonGateway
    {
        public List<Student> GetAllStudents()
        {
            Query = "SELECT *FROM Students";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = int.Parse(reader["StudentId"].ToString());
                    student.StudentName = reader["StudentName"].ToString();
                    student.StudentEmail = reader["StudentEmail"].ToString();
                    student.StudentContactNo = reader["StudentContactNo"].ToString();
                    student.StudentRegDate = DateTime.Parse(reader["StudentRegDate"].ToString());
                    student.StudentAddress = reader["StudentAddress"].ToString();
                    student.StudentDepartmentId = int.Parse(reader["StudentDepartmentId"].ToString());
                    student.StudentDepartmentCode = reader["StudentDepartmentCode"].ToString();
                    student.StudentRegistrationNo = reader["StudentRegistrationNo"].ToString();
                    students.Add(student);
                }
                reader.Close();
            }
            Connection.Close();
            return students;
        }
        public int SaveStudent(Student student)
        {
            Query = "INSERT INTO Students(StudentName,StudentEmail,StudentContactNo,StudentRegDate,StudentAddress,StudentDepartmentId,StudentDepartmentCode,StudentRegistrationNo) VALUES(@StudentName,@StudentEmail,@StudentContactNo,@StudentRegDate,@StudentAddress,@StudentDepartmentId,@StudentDepartmentCode,@StudentRegistrationNo)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("StudentName", SqlDbType.VarChar);
            Command.Parameters["StudentName"].Value = student.StudentName;
            Command.Parameters.Add("StudentEmail", SqlDbType.VarChar);
            Command.Parameters["StudentEmail"].Value = student.StudentEmail;
            Command.Parameters.Add("StudentContactNo", SqlDbType.VarChar);
            Command.Parameters["StudentContactNo"].Value = student.StudentContactNo;
            Command.Parameters.Add("StudentRegDate", SqlDbType.Date);
            Command.Parameters["StudentRegDate"].Value = student.StudentRegDate;
            Command.Parameters.Add("StudentAddress", SqlDbType.VarChar);
            Command.Parameters["StudentAddress"].Value = student.StudentAddress;
            Command.Parameters.Add("StudentDepartmentId", SqlDbType.Int);
            Command.Parameters["StudentDepartmentId"].Value = student.StudentDepartmentId;
            Command.Parameters.Add("StudentDepartmentCode", SqlDbType.VarChar);
            Command.Parameters["StudentDepartmentCode"].Value = student.StudentDepartmentCode;
            Command.Parameters.Add("StudentRegistrationNo", SqlDbType.VarChar);
            Command.Parameters["StudentRegistrationNo"].Value = student.StudentRegistrationNo;
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int EnrollCourse(EnrollCourse enrollCourse)
        {
            Query = "INSERT INTO EnrolledCourses(EnrollCourseStudentId,EnrollCourseCourseId,EnrollCourseCourseCode,EnrollCourseCourseName,EnrollCourseDate) VALUES(@EnrollCourseStudentId,@EnrollCourseCourseId,@EnrollCourseCourseCode,@EnrollCourseCourseName,@EnrollCourseDate)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("EnrollCourseStudentId", SqlDbType.Int);
            Command.Parameters["EnrollCourseStudentId"].Value = enrollCourse.EnrollCourseStudentId;
            Command.Parameters.Add("EnrollCourseCourseId", SqlDbType.Int);
            Command.Parameters["EnrollCourseCourseId"].Value = enrollCourse.EnrollCourseCourseId;
            Command.Parameters.Add("EnrollCourseCourseCode", SqlDbType.VarChar);
            Command.Parameters["EnrollCourseCourseCode"].Value = enrollCourse.EnrollCourseCourseCode;
            Command.Parameters.Add("EnrollCourseCourseName", SqlDbType.VarChar);
            Command.Parameters["EnrollCourseCourseName"].Value = enrollCourse.EnrollCourseCourseName;
            Command.Parameters.Add("EnrollCourseDate", SqlDbType.Date);
            Command.Parameters["EnrollCourseDate"].Value = enrollCourse.EnrollCourseDate;
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<EnrollCourse> GetAllEnrolledCourses()
        {
            Query = "SELECT *FROM EnrolledCourses";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<EnrollCourse> enrollCourses = new List<EnrollCourse>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EnrollCourse enrollCourse = new EnrollCourse();
                    enrollCourse.EnrollCourseId = int.Parse(reader["EnrollCourseId"].ToString());
                    enrollCourse.EnrollCourseStudentId = int.Parse(reader["EnrollCourseStudentId"].ToString());
                    enrollCourse.EnrollCourseCourseId = int.Parse(reader["EnrollCourseCourseId"].ToString());
                    enrollCourse.EnrollCourseCourseCode = reader["EnrollCourseCourseCode"].ToString();
                    enrollCourse.EnrollCourseCourseName = reader["EnrollCourseCourseName"].ToString();
                    enrollCourse.EnrollCourseDate = DateTime.Parse(reader["EnrollCourseDate"].ToString());
                    enrollCourses.Add(enrollCourse);
                }
                reader.Close();
            }
            Connection.Close();
            return enrollCourses;
        }
    }
}