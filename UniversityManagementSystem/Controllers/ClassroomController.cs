using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        //DepartmentManager departmentManager=new DepartmentManager();
        AllocateClassroomManager allocateClassroomManager=new AllocateClassroomManager();
        //CourseManager courseManager=new CourseManager();
        ClassScheduleManager classScheduleManager =new ClassScheduleManager();
        GetAllTables getAllTables=new GetAllTables();
        public ActionResult AllocateClassroom()
        {
            ViewBag.Departments = getAllTables.GetAllDepartments();
            ViewBag.Days = getAllTables.GetAllDays();
            ViewBag.Rooms = getAllTables.GetAllRooms();
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClassroom(AllocateClassroom allocateClassroom)
        {
            ViewBag.Departments = getAllTables.GetAllDepartments();
            ViewBag.Days = getAllTables.GetAllDays();
            ViewBag.Rooms = getAllTables.GetAllRooms();
            Course course = getAllTables.GetAllCourses().FirstOrDefault(a => a.CourseId == allocateClassroom.AllocateClassroomCourseId);
            ClassSchedule classSchedule = getAllTables.GetAllClassSchedule().FirstOrDefault(a=>a.ClassScheduleCourseCode==course.CourseCode);
            Room room = getAllTables.GetAllRooms().FirstOrDefault(a => a.RoomId == allocateClassroom.AllocateClassroomRoomId);
            Day day = getAllTables.GetAllDays().FirstOrDefault(a => a.DayId == allocateClassroom.AllocateClassroomDayId);
            string scheduleDetails = "Room No.: " + room.RoomName + "," + day.DayName + "," + allocateClassroom.AllocateClassroomFrom.ToString("hh:mm tt") + "-" + allocateClassroom.AllocateClassroomTo.ToString("hh:mm tt");
            if (classSchedule.ClassScheduleInfo == "Not Scheduled Yet")
            {
                classSchedule.ClassScheduleInfo = "";
            }
            if (classSchedule.ClassScheduleInfo == "")
            {
                classSchedule.ClassScheduleInfo += scheduleDetails;
            }
            else
            {
                classSchedule.ClassScheduleInfo +=";<br/>"+ scheduleDetails;
            }
            List<AllocateClassroom> allocateClassroomList = getAllTables.GetAllAllocationInfo().Where(a => a.AllocateClassroomDayId == allocateClassroom.AllocateClassroomDayId ).ToList();
            if (allocateClassroomList.Count > 0)
            {
                TimeSpan requestedForm = allocateClassroom.AllocateClassroomFrom.TimeOfDay;
                TimeSpan requestedTo = allocateClassroom.AllocateClassroomTo.TimeOfDay;
                int count = 0;
                foreach (var allocatedClassroom in allocateClassroomList)
                {
                    count++;
                    TimeSpan allocatedForm = allocatedClassroom.AllocateClassroomFrom.TimeOfDay;
                    TimeSpan allocatedTo = allocatedClassroom.AllocateClassroomTo.TimeOfDay;
                    if (allocatedClassroom.AllocateClassroomCourseId == allocateClassroom.AllocateClassroomCourseId)
                    {
                        if (TimeSpan.Compare(allocatedTo, requestedForm) < 0 || TimeSpan.Compare(allocatedForm, requestedForm) > 0 && TimeSpan.Compare(allocatedForm, requestedTo) > 0)
                        {
                            ViewBag.Message = allocateClassroomManager.AllocateClassroom(allocateClassroom) && classScheduleManager.UpdateClassSchedul(classSchedule) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
                            break;
                        }
                        ViewBag.Message = "Course Already Allocated For This Time";
                        break;
                    }
                    else if (allocatedClassroom.AllocateClassroomRoomId == allocateClassroom.AllocateClassroomRoomId)
                    {
                        if (TimeSpan.Compare(allocatedTo, requestedForm) < 0 || TimeSpan.Compare(allocatedForm, requestedForm) > 0 && TimeSpan.Compare(allocatedForm, requestedTo) > 0)
                        {
                            ViewBag.Message = allocateClassroomManager.AllocateClassroom(allocateClassroom) && classScheduleManager.UpdateClassSchedul(classSchedule) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
                            break;
                        }
                        ViewBag.Message = "Room Already Allocated For This Time";
                        break;
                    }
                    else if (allocateClassroomList.Count == count)
                    {
                        ViewBag.Message = allocateClassroomManager.AllocateClassroom(allocateClassroom) && classScheduleManager.UpdateClassSchedul(classSchedule) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
                        break;
                    }
                }
            }
            else
            {
                ViewBag.Message = allocateClassroomManager.AllocateClassroom(allocateClassroom) && classScheduleManager.UpdateClassSchedul(classSchedule) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
            }
            return View();
        }
        public ActionResult ClassroomSchedule()
        {
            ViewBag.DepartmentList = getAllTables.GetAllDepartments();
            return View();
        }
        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courseList = getAllTables.GetAllCourses().Where(a => a.CourseDepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClassScheduleByDepartmentId(int departmentId)
        {
            var classroomSchedule = classScheduleManager.GetAllClassSchedule();
            var classroomScheduleList = classroomSchedule.Where(a => a.ClassScheduleDepartmentId == departmentId).ToList();
            if (classroomScheduleList.Count == 0)
            {
                string flag = "";
                return Json(flag, JsonRequestBehavior.AllowGet);
            }
            return Json(classroomScheduleList, JsonRequestBehavior.AllowGet);
        }
    }
}