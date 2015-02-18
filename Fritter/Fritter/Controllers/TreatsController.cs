using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fritter.Models;

namespace Fritter.Controllers
{
    public class TreatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Treats
        public ActionResult Index()
        {
            return View(db.Treats.ToList());
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
        public ActionResult Create([Bind(Include = "TreatId,Text,UserName,Timestamp")] Treat treat)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "TreatId,Text,UserName,Timestamp")] Treat treat)
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
