using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.DAL
{
    public class ResetAllGateway:CommonGateway
    {
        public int UnassignAllCourses()
        {
            Query = "UPDATE CourseStatics SET CourseStatusTeacherName='" + "" + "'" + ",CourseStatusIsAssigned='NO'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public int UnallocateAllClassrooms()
        {
            Query = "UPDATE ClassSchedules SET ClassScheduleInfo='" + "" + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public int ResetClassrooms()
        {
            Query = "DELETE FROM AllocateClassrooms";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
    }
}