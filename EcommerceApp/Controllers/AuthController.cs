using System;
using System.Threading.Tasks;
using EcommerceCore.Interfaces;
using EcommerceCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.Login(model);

                if (result != null)
                {

                    HttpContext.Session.SetString("Fullname", result.FullName);
                    HttpContext.Session.SetString("userId", result.Id);
                    return RedirectToAction("Index", "Home");
                }

            }
                

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.Register(model);

                if (result)
                    return RedirectToAction("Login");
            }

            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
