using QL_TrungTam_X.Areas.QuanLy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using QL_TrungTam_X.Common;

namespace QL_TrungTam_X.Areas.QuanLy.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /QuanLy/Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.UserID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu.");
                }
            }
            return View("Index");
        }
	}
}