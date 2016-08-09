using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocateClassroom
    {
        public int AllocateClassroomId { get; set; }
        public int AllocateClassroomDepartmentId { get; set; }
        public int AllocateClassroomCourseId { get; set; }
        public int AllocateClassroomRoomId { get; set; }
        public int AllocateClassroomDayId { get; set; }
        public DateTime AllocateClassroomFrom { get; set; }
        public DateTime AllocateClassroomTo { get; set; }
        public string IsAllocate { get; set; }
    }
}