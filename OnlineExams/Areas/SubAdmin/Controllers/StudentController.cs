using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExams.Areas.SubAdmin.Controllers
{
    public class StudentController : Controller
    {
        // GET: SubAdmin/Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Student()
        {
            return View();
        }
    }
}