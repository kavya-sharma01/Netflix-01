using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Model.Models;
using Netflix.Model.Request;
using Netflix.Service.Interface;
using Netflix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Netflix.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }
        public IActionResult Index()
        {
            return View();
        }
       /*public IActionResult Retrieve(int? page)
        {
            var PageNumber = page ?? 1;
            int PageSize = 3;
            var OnePageOfUsers = Data.NetflixDbContext.DbSet.Users.ToPagedList(PageNumber, PageSize);
            return View(OnePageOfUsers);

        }*/
        [HttpGet]
        public IActionResult Retrieve(int page = 2, int pagesize = 5)
        {
            if (HttpContext.Session.GetString("Useremail") == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            // List<Users> listuser = new List<Users>();
            var userlist = _userservice.Retrieveuser(page,pagesize);

            return View(userlist);
        }

        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Registration(UsersRequest request)
        {
            _userservice.SaveUser(request);
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var result = _userservice.DeleteUser(id);
            if (result.deleted == true)
            {

                TempData["deleted"] = true;
                TempData["Errormessage"] = result.Errormessage;
                return RedirectToAction("Retrieve", "User");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = _userservice.EditUser(id);

            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> EditPost(Users user)
        {
            var result = _userservice.Edited(user);
            if (result.edited == true)
            {
                TempData["deleted"] = true;
                TempData["Errormessage"] = result.message;
                return RedirectToAction("Retrieve", "User");
            }
            return View();
        }
    }



}
