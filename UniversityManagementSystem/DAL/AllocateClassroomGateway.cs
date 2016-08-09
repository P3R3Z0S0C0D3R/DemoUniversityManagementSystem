using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class AllocateClassroomGateway:CommonGateway
    {
        public List<Day> GetAllDays()
        {
            Query = "SELECT *FROM Days ORDER BY DayId ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Day> days = new List<Day>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Day day = new Day();
                    day.DayId = int.Parse(reader["DayId"].ToString());
                    day.DayName = reader["DayName"].ToString();
                    days.Add(day);
                }
                reader.Close();
            }
            Connection.Close();
            return days;
        }

        public List<Room> GetAllRooms()
        {
            Query = "SELECT *FROM Rooms ORDER BY RoomId ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Room room = new Room();
                    room.RoomId = int.Parse(reader["RoomId"].ToString());
                    room.RoomName = reader["RoomName"].ToString();
                    rooms.Add(room);
                }
                reader.Close();
            }
            Connection.Close();
            return rooms;
        }

        public int AllocateClassroom(AllocateClassroom allocateClassroom)
        {
            Query = "INSERT INTO AllocateClassrooms(AllocateClassroomDepartmentId,AllocateClassroomCourseId,AllocateClassroomRoomId,AllocateClassroomDayId,AllocateClassroomFrom,AllocateClassroomTo,IsAllocate) VALUES(@AllocateClassroomDepartmentId,@AllocateClassroomCourseId,@AllocateClassroomRoomId,@AllocateClassroomDayId,@AllocateClassroomFrom,@AllocateClassroomTo,@IsAllocate)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("AllocateClassroomDepartmentId", SqlDbType.Int);
            Command.Parameters["AllocateClassroomDepartmentId"].Value = allocateClassroom.AllocateClassroomDepartmentId;
            Command.Parameters.Add("AllocateClassroomCourseId", SqlDbType.Int);
            Command.Parameters["AllocateClassroomCourseId"].Value = allocateClassroom.AllocateClassroomCourseId;
            Command.Parameters.Add("AllocateClassroomRoomId", SqlDbType.Int);
            Command.Parameters["AllocateClassroomRoomId"].Value = allocateClassroom.AllocateClassroomRoomId;
            Command.Parameters.Add("AllocateClassroomDayId", SqlDbType.Int);
            Command.Parameters["AllocateClassroomDayId"].Value = allocateClassroom.AllocateClassroomDayId;
            Command.Parameters.Add("AllocateClassroomFrom", SqlDbType.Time);
            Command.Parameters["AllocateClassroomFrom"].Value = allocateClassroom.AllocateClassroomFrom.TimeOfDay;
            Command.Parameters.Add("AllocateClassroomTo", SqlDbType.Time);
            Command.Parameters["AllocateClassroomTo"].Value = allocateClassroom.AllocateClassroomTo.TimeOfDay;
            Command.Parameters.Add("IsAllocate", SqlDbType.VarChar);
            Command.Parameters["IsAllocate"].Value = "YES";
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<AllocateClassroom> GetAllAllocationInfo()
        {
            Query = "SELECT *FROM AllocateClassrooms WHERE IsAllocate='"+"YES"+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<AllocateClassroom> roomsAllocateClassrooms = new List<AllocateClassroom>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllocateClassroom roomAllocateClassroom = new AllocateClassroom();
                    roomAllocateClassroom.AllocateClassroomId = int.Parse(reader["AllocateClassroomId"].ToString());
                    roomAllocateClassroom.AllocateClassroomDepartmentId = int.Parse(reader["AllocateClassroomDepartmentId"].ToString());
                    roomAllocateClassroom.AllocateClassroomCourseId = int.Parse(reader["AllocateClassroomCourseId"].ToString());
                    roomAllocateClassroom.AllocateClassroomRoomId = int.Parse(reader["AllocateClassroomRoomId"].ToString());
                    roomAllocateClassroom.AllocateClassroomDayId = int.Parse(reader["AllocateClassroomDayId"].ToString());
                    roomAllocateClassroom.AllocateClassroomFrom = DateTime.Parse(reader["AllocateClassroomFrom"].ToString());
                    roomAllocateClassroom.AllocateClassroomTo = DateTime.Parse(reader["AllocateClassroomTo"].ToString());
                    roomAllocateClassroom.IsAllocate = reader["IsAllocate"].ToString();
                    roomsAllocateClassrooms.Add(roomAllocateClassroom);
                }
                reader.Close();
            }
            Connection.Close();
            return roomsAllocateClassrooms;
        }
        public Room GetRoomById(int roomId)
        {
            Query = "SELECT *FROM Rooms WHERE RoomId="+roomId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            Room room = new Room();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    room.RoomId = int.Parse(reader["RoomId"].ToString());
                    room.RoomName = reader["RoomName"].ToString();
                }
                reader.Close();
            }
            Connection.Close();
            return room;
        }

        public Day GetDayById(int dayId)
        {
            Query = "SELECT *FROM Days WHERE DayId="+dayId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            Day day = new Day();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    day.DayId = int.Parse(reader["DayId"].ToString());
                    day.DayName = reader["DayName"].ToString();
                }
                reader.Close();
            }
            Connection.Close();
            return day;
        }
    }
}