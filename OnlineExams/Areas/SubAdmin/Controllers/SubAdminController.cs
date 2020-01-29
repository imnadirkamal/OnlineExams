using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExams.BAL.Repository;
using OnlineExams.BAL.Models;

namespace OnlineExams.Areas.SubAdmin.Controllers
{
    public class SubAdminController : Controller
    {
        IUserRepo _userRepo;

        public SubAdminController()
        {
            _userRepo = new UserRepo();
        }

        // GET: SubAdmin/SubAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SubAdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubAdminLogin(UserInfo _userInfo)
        {
            DataSet ds = _userRepo.UserLoginAuthentication(_userInfo);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["UserId"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                    Session["Username"] = ds.Tables[0].Rows[0]["username"].ToString();
                    Session["UserGroup"] = ds.Tables[0].Rows[0]["UserGroup"].ToString();
                }
            }
            return RedirectToAction("SubAdminDashboard", "SubAdmin");
        }
        public ActionResult SubAdminDashboard()
        {
            return View();
        }
        #region Questions
        public ActionResult Subjects()
        {
            return View();
        }
        public ActionResult CreateSubject()
        {
            
            return View();
        }
        #endregion

    }
}