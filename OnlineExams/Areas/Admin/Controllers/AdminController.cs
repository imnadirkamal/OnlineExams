using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExams.BAL.Repository;
using OnlineExams.BAL.Models;

namespace OnlineExams.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        IUserRepo _userRepo;
        public AdminController()
        {
            _userRepo = new UserRepo();
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserInfo _userInfo)
        {
            DataSet dt = _userRepo.UserLoginAuthentication(_userInfo);


            return RedirectToAction("AdminDashboard","Admin");
        }
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}