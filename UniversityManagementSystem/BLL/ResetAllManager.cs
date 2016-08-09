using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;

namespace UniversityManagementSystem.BLL
{
    public class ResetAllManager
    {
        ResetAllGateway resetAllGateway = new ResetAllGateway();
        public bool UnassignAllCourses()
        {
            return resetAllGateway.UnassignAllCourses() > 0;
        }
        public bool UnallocateAllClassrooms()
        {
            return resetAllGateway.UnallocateAllClassrooms() > 0 && resetAllGateway.ResetClassrooms() > 0;
        }
    }
}