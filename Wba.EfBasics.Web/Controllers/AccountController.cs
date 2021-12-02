using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Wba.EfBasics.Web.ViewModels;

namespace Wba.EfBasics.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLoginViewModel accountLoginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(accountLoginViewModel);
            }
            //check user  and
            //check credentials
            //create a cookie and add to response object
            //create cookie options
            CookieOptions cookieOptions = new();
            cookieOptions.Expires = DateTime.Now.AddMinutes(3);
            //create ze cookie
            //voor good practice; hash the username store hash in cookie
            //and store hash/username in database
            Response.Cookies.Append("Login",accountLoginViewModel.Username,cookieOptions);
            //create a session for our user
            HttpContext.Session.SetInt32("LoggedIn", 1);
            HttpContext.Session.SetString("UserName", accountLoginViewModel.Username);
            return RedirectToAction("Index", "Courses");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
