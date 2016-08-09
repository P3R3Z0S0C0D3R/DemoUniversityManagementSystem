using System.Data.SqlClient;
using System.Web.Configuration;

namespace UniversityManagementSystem.DAL
{
    public class CommonGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManagementApp"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public string Query { get; set; }
        public CommonGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}