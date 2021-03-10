using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Model;
using Netflix.Model.Request;
using Netflix.Service;
using Netflix.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Netflix.Controllers
{
    public class Authentication : Controller
    {
      /*  private readonly IAuthenticationService authenticationservice;
        public Authentication(IAuthenticationService authenticationService)
        {
            this.authenticationservice = authenticationService;
        }*/
       
       private ILogin _userlogin;
        public Authentication(ILogin userlogin)
        {
            _userlogin = userlogin;
        }
       public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Useremail") == "k@gmail.com" && HttpContext.Session.GetString("Password") == "123")
            {
                return RedirectToAction("Retrieve", "User");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
           /*var isLogined =  authenticationservice.ValidateEmailAndPassword(request.email, request.ps);
            if (isLogined == true)
            {
               return RedirectToAction("Retrieve", "User");
            }
            ViewBag.IsInvalidCreds = true;
            return View();*/
            // if (ModelState.IsValid)
            //{
            //  bool logined = _userlogin.LoginProcess(request);
            //if (logined == true)
            //{
            //  return RedirectToAction("Retrieve", "User");
            //}
            //ViewBag.ValidCredentials = false;
            //}
           if (ModelState.IsValid)
            {


                var logined = _userlogin.LoginProcess(request);
                if (logined.IsLoginSuccess == true)
                {
                    HttpContext.Session.SetString("Useremail", request.email);
                    HttpContext.Session.SetString("Password", request.ps);
                    return RedirectToActionPermanent("Retrieve", "User");
                }
                ViewBag.ValidCredentials = false;
                ViewBag.error = logined.Error;
            }
            return View();
            
        }
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToActionPermanent("Login", "Authentication");
            return View();

        }


       /* public ActionResult Logout(int? page)
        {
            var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }*/

    }
}
