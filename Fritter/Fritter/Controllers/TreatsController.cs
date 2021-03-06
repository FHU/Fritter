﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fritter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fritter.Controllers
{
    public class TreatsController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public TreatsController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
        
        // GET: Treats
        public ActionResult Index()
        {
            return View(db.Treats.ToList());
        }

        public ActionResult MyTreats()
        {
            // get current user
            var user = UserManager.FindById(User.Identity.GetUserId());
            
            // find treats by current user
            var treatsFromUser = 
                ( from t in db.Treats 
                  where t.CreatorID == user.Id
                select t );
                         
            return View(treatsFromUser);
        }

        // GET: Treats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treat treat = db.Treats.Find(id);
            if (treat == null)
            {
                return HttpNotFound();
            }
            return View(treat);
        }

        // GET: Treats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatId,Text,TimeStamp")] Treat treat)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());

                treat.CreatorID = user.Id;

                db.Treats.Add(treat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treat);
        }

        // GET: Treats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treat treat = db.Treats.Find(id);
            if (treat == null)
            {
                return HttpNotFound();
            }
            return View(treat);
        }

        // POST: Treats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatId,Text,TimeStamp")] Treat treat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treat);
        }

        // GET: Treats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treat treat = db.Treats.Find(id);
            if (treat == null)
            {
                return HttpNotFound();
            }
            return View(treat);
        }

        // POST: Treats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat treat = db.Treats.Find(id);
            db.Treats.Remove(treat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
