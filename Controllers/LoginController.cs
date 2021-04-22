using LoginApp.Models;
using LoginApp.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        //public string Login(UserModel userModel)
        //{
        //    //  return "Results: Username = ' " + userModel.Username + " ' PW '" + userModel.Password;

        //    SecurityService service = new SecurityService();
        //  Boolean Success =  service.Authenticate(userModel);
        //    if(Success)
        //    {
        //        return "Success login!";
        //    }
        //    else
        //    {
        //        return "Failure!";
        //    }
        //}
        public ActionResult Login(UserModel userModel)
        {
            SecurityService service = new SecurityService();
            Boolean Success = service.Authenticate(userModel);
            if (Success)
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("Failure");

            }
        }
    }
}

        
    