using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class LoginController : Controller
    {
        //Magic and Youtube tutorials

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        
        //Authorize For Password
        [HttpPost]
        public ActionResult Autherize(Lab4.Models.admin userModel)
        {
            using (UsersEntities db = new UsersEntities())
            {
                var userDetails = db.admins.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel); 
                }
                else
                {
                    Session["Id"] = userDetails.Id;
                    Session["userName"] = userDetails.username;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //Logout
        public ActionResult LogOut()
        {
            int userId = (int)Session["Id"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        //Create 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, username, password")] admin admin)
        {
            using (UsersEntities db = new UsersEntities())
                if (ModelState.IsValid)
            {
                db.admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }


    }
}