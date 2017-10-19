using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        // GET: ClassRoom
        private ClassRoomManager classRoomManager = new ClassRoomManager();
        private List<SelectListItem> GetAllDay()
        {
            List<SelectListItem> Day = new List<SelectListItem>
            {

                new SelectListItem {Value = "Sat", Text = "Saterday"},
                new SelectListItem {Value = "Sun", Text = "Sunday"},
                new SelectListItem {Value = "Mon", Text = "Monday"},
                new SelectListItem {Value = "Twe", Text = "Twesday"},
                new SelectListItem {Value = "Wed", Text = "Wednesday"},
                new SelectListItem {Value = "Thu", Text = "Thusday"},
                new SelectListItem {Value = "Fri", Text = "Friday"}

            };
            return Day;
        }
        private List<SelectListItem> GetAllRoomNo()
        {
            List<SelectListItem> RoomNo = new List<SelectListItem>
            {

                new SelectListItem {Value = "R.NO:A-101", Text = "A-101"},
                new SelectListItem {Value = "R.NO:A-102", Text = "A-102"},
                new SelectListItem {Value = "R.NO:A-103", Text = "A-103"},
                new SelectListItem {Value = "R.NO:A-104", Text = "A-104"},
                new SelectListItem {Value = "R.NO:A-201", Text = "A-201"},
                new SelectListItem {Value = "R.NO:A-202", Text = "A-202"},
                new SelectListItem {Value = "R.NO:A-203", Text = "A-203"},
                new SelectListItem {Value = "R.NO:A-204", Text = "A-204"},
                new SelectListItem {Value = "R.NO:B-101", Text = "B-101"},
                new SelectListItem {Value = "R.NO:B-102", Text = "B-102"},
                new SelectListItem {Value = "R.NO:B-103", Text = "B-103"},
                new SelectListItem {Value = "R.NO:B-104", Text = "B-104"},
                new SelectListItem {Value = "R.NO:B-201", Text = "B-201"},
                new SelectListItem {Value = "R.NO:B-202", Text = "B-202"},
                new SelectListItem {Value = "R.NO:B-203", Text = "B-203"},
                new SelectListItem {Value = "R.NO:B-204", Text = "B-204"}
            };

            return RoomNo;
        }
        public ActionResult ClassSchedul()
        {
            ViewBag.listOfDepartments = classRoomManager.GetAllDepartments();
            return View();
        }

        public JsonResult GetClassroomSheduleByDepartmentId(int deptId)
        {
            var sheduleList = classRoomManager.GetAllClassSheduleIntoList();
            var courseSheduleList = sheduleList.Where(x => x.DepartmentId == deptId).ToList();


            foreach (var classShedule in courseSheduleList)
            {
                if (classShedule.SheduleInfo.Length < 1)
                {
                    classShedule.SheduleInfo = "Not Scheduled Yet";
                }
            }



            return Json(courseSheduleList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseCodeByDepartmentId(int deptId)
        {
            var courses = classRoomManager.GetAllCourses();
            var studentList = courses.Where(x => x.DepartmentId == deptId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Allocate()
        {
            ViewBag.departmentList = classRoomManager.GetAllDepartments();
            ViewBag.roomNo = GetAllRoomNo();
            ViewBag.day = GetAllDay();
            return View();
        }
        [HttpPost]
        public ActionResult Allocate(AllocateClassRoom allocateClassRoom)
        {
            ViewBag.message = classRoomManager.SaveAllocatedClassRoom(allocateClassRoom);
            ViewBag.departmentList = classRoomManager.GetAllDepartments();
            ViewBag.roomNo = GetAllRoomNo();
            ViewBag.day = GetAllDay();
            return View();
        }
    }
}