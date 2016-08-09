using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class ArchiveManager
    {
        ArchiveGateway archiveGateway=new ArchiveGateway();
        public bool UnassignAllCourses()
        {
            return archiveGateway.UnassignAllCourses() > 0;
        }
        public bool UnallocateAllClassrooms()
        {
            return archiveGateway.UnallocateAllClassrooms() > 0;
        }

        public List<ArchivedCourseStatus> GetAllArchivedCourseStatus()
        {
            return archiveGateway.GetAllArchivedCourseStatus();
        }
        public List<ArchivedClassSchedule> GetAllArchivedClassSchedules()
        {
            return archiveGateway.GetAllArchivedClassSchedules();
        }
    }
}