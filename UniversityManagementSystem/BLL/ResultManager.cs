using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class ResultManager
    {
        ResultGateway resultGateway = new ResultGateway();
        public List<Grade> GetAllGrades()
        {
            return resultGateway.GetAllGrades();
        }

        public bool SaveStudentResult(Result result)
        {
            return resultGateway.SaveStudentResult(result) > 0;
        }

        public List<Result> GetStudentResult()
        {
            return resultGateway.GetStudentResult();
        }
    }
}