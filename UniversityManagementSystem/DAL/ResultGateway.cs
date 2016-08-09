using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class ResultGateway:CommonGateway
    {
        public List<Grade> GetAllGrades()
        {
            Query = "SELECT *FROM Grades";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Grade grade = new Grade();
                    grade.GradeId = int.Parse(reader["GradeId"].ToString());
                    grade.GradeName = reader["GradeName"].ToString();
                    grades.Add(grade);
                }
                reader.Close();
            }
            Connection.Close();
            return grades;
        }

        public int SaveStudentResult(Result result)
        {
            Query = "INSERT INTO Results(ResultStudentId,ResultStudentCourseId,ResultStudentCourseCode,ResultStudentCourseName,ResultGradeId,ResultGradeName) VALUES(@ResultStudentId,@ResultStudentCourseId,@ResultStudentCourseCode,@ResultStudentCourseName,@ResultGradeId,@ResultGradeName)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("ResultStudentId", SqlDbType.Int);
            Command.Parameters["ResultStudentId"].Value = result.ResultStudentId;
            Command.Parameters.Add("ResultStudentCourseId", SqlDbType.Int);
            Command.Parameters["ResultStudentCourseId"].Value = result.ResultStudentCourseId;
            Command.Parameters.Add("ResultStudentCourseCode", SqlDbType.VarChar);
            Command.Parameters["ResultStudentCourseCode"].Value = result.ResultStudentCourseCode;
            Command.Parameters.Add("ResultStudentCourseName", SqlDbType.VarChar);
            Command.Parameters["ResultStudentCourseName"].Value = result.ResultStudentCourseName;
            Command.Parameters.Add("ResultGradeId", SqlDbType.Int);
            Command.Parameters["ResultGradeId"].Value = result.ResultGradeId;
            Command.Parameters.Add("ResultGradeName", SqlDbType.VarChar);
            Command.Parameters["ResultGradeName"].Value = result.ResultGradeName;
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Result> GetStudentResult()
        {
            Query = "SELECT *FROM Results";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Result> results = new List<Result>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Result result = new Result();
                    result.ResultId = int.Parse(reader["ResultId"].ToString());
                    result.ResultStudentId = int.Parse(reader["ResultStudentId"].ToString());
                    result.ResultStudentCourseId = int.Parse(reader["ResultStudentCourseId"].ToString());
                    result.ResultStudentCourseCode = reader["ResultStudentCourseCode"].ToString();
                    result.ResultStudentCourseName = reader["ResultStudentCourseName"].ToString();
                    result.ResultGradeId = int.Parse(reader["ResultGradeId"].ToString());
                    result.ResultGradeName = reader["ResultGradeName"].ToString();
                    results.Add(result);
                }
                reader.Close();
            }
            Connection.Close();
            return results;
        }
    }
}