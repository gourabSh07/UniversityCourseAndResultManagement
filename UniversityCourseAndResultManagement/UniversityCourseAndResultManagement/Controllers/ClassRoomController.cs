using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;

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
                new SelectListItem {Value = "R.NO:A-204", Text = "A-204"}
            };

            return RoomNo;
        }
    }
}