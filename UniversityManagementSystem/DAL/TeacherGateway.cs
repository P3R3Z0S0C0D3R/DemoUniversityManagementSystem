using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class TeacherGateway:CommonGateway
    {
        //public bool IsEmailExists(string teacherEmail)
        //{
        //    Query = "SELECT * FROM Teachers WHERE TeacherEmail = '" + teacherEmail + "'";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    bool isEmailExists = reader.HasRows;
        //    Connection.Close();
        //    return isEmailExists;
        //}
        public int SaveTeacher(Teacher teacher)
        {
            Query = "INSERT INTO Teachers(TeacherName,TeacherAddress,TeacherEmail,TeacherContactNo,TeacherDesignationId,TeacherDepartmentId,CreditToBeTaken,RemainingCredit) VALUES(@TeacherName,@TeacherAddress,@TeacherEmail,@TeacherContactNo,@TeacherDesignationId,@TeacherDepartmentId,@CreditToBeTaken,@RemainingCredit)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("TeacherName", SqlDbType.VarChar);
            Command.Parameters["TeacherName"].Value = teacher.TeacherName;
            Command.Parameters.Add("TeacherAddress", SqlDbType.VarChar);
            Command.Parameters["TeacherAddress"].Value = teacher.TeacherAddress;
            Command.Parameters.Add("TeacherEmail", SqlDbType.VarChar);
            Command.Parameters["TeacherEmail"].Value = teacher.TeacherEmail;
            Command.Parameters.Add("TeacherContactNo", SqlDbType.VarChar);
            Command.Parameters["TeacherContactNo"].Value = teacher.TeacherContactNo;
            Command.Parameters.Add("TeacherDesignationId", SqlDbType.Int);
            Command.Parameters["TeacherDesignationId"].Value = teacher.TeacherDesignationId;
            Command.Parameters.Add("TeacherDepartmentId", SqlDbType.Int);
            Command.Parameters["TeacherDepartmentId"].Value = teacher.TeacherDepartmentId;
            Command.Parameters.Add("CreditToBeTaken", SqlDbType.Decimal);
            Command.Parameters["CreditToBeTaken"].Value = teacher.CreditToBeTaken;
            Command.Parameters.Add("RemainingCredit", SqlDbType.Decimal);
            Command.Parameters["RemainingCredit"].Value = teacher.CreditToBeTaken;
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT *FROM Teachers ORDER BY TeacherName ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherId = int.Parse(reader["TeacherId"].ToString());
                    teacher.TeacherName = reader["TeacherName"].ToString();
                    teacher.TeacherAddress = reader["TeacherAddress"].ToString();
                    teacher.TeacherEmail = reader["TeacherEmail"].ToString();
                    teacher.TeacherContactNo = reader["TeacherContactNo"].ToString();
                    teacher.TeacherDesignationId = int.Parse(reader["TeacherDesignationId"].ToString());
                    teacher.TeacherDepartmentId = int.Parse(reader["TeacherDepartmentId"].ToString());
                    teacher.CreditToBeTaken = double.Parse(reader["CreditToBeTaken"].ToString());
                    teacher.RemainingCredit = double.Parse(reader["RemainingCredit"].ToString());
                    teachers.Add(teacher);
                }
                reader.Close();
            }
            Connection.Close();
            return teachers;
        }
        public List<Designation> GetAllDesignations()
        {
            Query = "SELECT * FROM Designations";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Designation designation = new Designation();
                    designation.DesignationId = int.Parse(reader["DesignationId"].ToString());
                    designation.DesignationName = reader["DesignationName"].ToString();
                    designations.Add(designation);
                }
                reader.Close();
            }
            Connection.Close();
            return designations;
        }
        //public Teacher GetTeacherDetails(int teacherId)
        //{
        //    Query = "SELECT *FROM Teachers WHERE TeacherId=" + teacherId;
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    Teacher teacher = new Teacher();
        //    if (reader.HasRows)
        //    {
        //        reader.Read();
        //        teacher.TeacherId = int.Parse(reader["TeacherId"].ToString());
        //        teacher.TeacherName = reader["TeacherName"].ToString();
        //        teacher.TeacherAddress = reader["TeacherAddress"].ToString();
        //        teacher.TeacherEmail = reader["TeacherEmail"].ToString();
        //        teacher.TeacherContactNo = reader["TeacherContactNo"].ToString();
        //        teacher.TeacherDesignationId = int.Parse(reader["TeacherDesignationId"].ToString());
        //        teacher.TeacherDepartmentId = int.Parse(reader["TeacherDepartmentId"].ToString());
        //        teacher.CreditToBeTaken = double.Parse(reader["CreditToBeTaken"].ToString());
        //        teacher.RemainingCredit = double.Parse(reader["RemainingCredit"].ToString());
        //        reader.Close();
        //    }
        //    Connection.Close();
        //    return teacher;
        //}
        public int AssignCourse(Teacher teacher, Course course)
        {
            if (UpdateTeacher(teacher) == 1 && UpdateCourseStatus(teacher, course) == 1) return 2;
            else return 0;
        }
        public int UpdateTeacher(Teacher teacher)
        {
            Query = "UPDATE Teachers SET RemainingCredit=" + teacher.RemainingCredit + "" + " WHERE TeacherId=" + teacher.TeacherId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public int UpdateAllTeacher()
        {
            List<Teacher> teachers = GetAllTeachers();
            int rowsAffected = 0;
            foreach (Teacher teacher in teachers)
            {
                Query = "UPDATE Teachers SET RemainingCredit=" + teacher.CreditToBeTaken + "" + " WHERE TeacherId=" + teacher.TeacherId;
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                rowsAffected += Command.ExecuteNonQuery();
                Connection.Close();
            }
            return rowsAffected;
        }
        public int UpdateCourseStatus(Teacher teacher, Course course)
        {
            Query = "UPDATE CourseStatics SET CourseStatusTeacherName='" + teacher.TeacherName + "'" + ",CourseStatusIsAssigned='YES' WHERE CourseStatusCourseCode='" + course.CourseCode + "'" + " AND CourseStatusDepartmentId=" + course.CourseDepartmentId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        //public bool IsCourseAssign(string courseCode)
        //{
        //    Query = "SELECT *FROM CourseStatics WHERE CourseStatusCourseCode='" + courseCode + "' AND CourseStatusIsAssigned='"+"YES"+"'";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    bool isCourseAssign = reader.HasRows;
        //    Connection.Close();
        //    return isCourseAssign;
        //}
    }
}