using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGateway allocateClassroomGateway=new AllocateClassroomGateway();
        public List<Day> GetAllDays()
        {
            return allocateClassroomGateway.GetAllDays();
        }
        public List<Room> GetAllRooms()
        {
            return allocateClassroomGateway.GetAllRooms();
        }

        public bool AllocateClassroom(AllocateClassroom allocateClassroom)
        {
            return allocateClassroomGateway.AllocateClassroom(allocateClassroom) > 0;
        }

        public List<AllocateClassroom> GetAllAllocationInfo()
        {
            return allocateClassroomGateway.GetAllAllocationInfo();
        }
        public Room GetRoomById(int roomId)
        {
            return allocateClassroomGateway.GetRoomById(roomId);
        }

        public Day GetDayById(int dayId)
        {
            return allocateClassroomGateway.GetDayById(dayId);
        }
    }
}