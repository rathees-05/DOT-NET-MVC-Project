using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class MVC_EmployeeController : Controller
    {
        private MVCprojectEntities1 db = new MVCprojectEntities1();

        // GET: MVC_Employee
        public ActionResult Index()
        {
            return View(db.MVC_Employee.ToList());
        }

        // GET: MVC_Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVC_Employee mVC_Employee = db.MVC_Employee.Find(id);
            if (mVC_Employee == null)
            {
                return HttpNotFound();
            }
            return View(mVC_Employee);
        }

        // GET: MVC_Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC_Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "E_Id,E_FirstName,E_LastName,E_mail,E_Contact")] MVC_Employee mVC_Employee)
        {
            if (ModelState.IsValid)
            {
                db.MVC_Employee.Add(mVC_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mVC_Employee);
        }

        // GET: MVC_Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVC_Employee mVC_Employee = db.MVC_Employee.Find(id);
            if (mVC_Employee == null)
            {
                return HttpNotFound();
            }
            return View(mVC_Employee);
        }

        // POST: MVC_Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "E_Id,E_FirstName,E_LastName,E_mail,E_Contact")] MVC_Employee mVC_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mVC_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mVC_Employee);
        }

        // GET: MVC_Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVC_Employee mVC_Employee = db.MVC_Employee.Find(id);
            if (mVC_Employee == null)
            {
                return HttpNotFound();
            }
            return View(mVC_Employee);
        }

        // POST: MVC_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MVC_Employee mVC_Employee = db.MVC_Employee.Find(id);
            db.MVC_Employee.Remove(mVC_Employee);
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
