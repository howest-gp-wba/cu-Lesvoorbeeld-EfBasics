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
            
            //log in
            return RedirectToAction("Index", "Courses");
        }

    }
}
