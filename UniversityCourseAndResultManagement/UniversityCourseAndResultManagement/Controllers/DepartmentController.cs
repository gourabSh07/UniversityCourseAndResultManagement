using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult Index()
        {
            List<Department> departments = departmentManager.GetAll().ToList();
            return View(departments);
        }



        public ActionResult Save()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            try
            {
                string message = departmentManager.Save(aDepartment);
                ViewBag.Mgs = message;
                return View();


            }
            catch (Exception exception)
            {
                ViewBag.Mgs = exception.InnerException.Message;

                return View();
            }
        }

    }
}