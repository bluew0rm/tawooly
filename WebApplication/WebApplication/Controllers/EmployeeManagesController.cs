using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EmployeeManagesController : Controller
    {
        private WebApplicationContext db = new WebApplicationContext();

        // GET: EmployeeManages
        public ActionResult Index()
        {
            return View(db.EmployeeManages.ToList());
        }

        // GET: EmployeeManages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeManage employeeManage = db.EmployeeManages.Find(id);
            if (employeeManage == null)
            {
                return HttpNotFound();
            }
            return View(employeeManage);
        }

        // GET: EmployeeManages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeManages/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,AGE,GENDER,PHONE,ADRESS")] EmployeeManage employeeManage)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeManages.Add(employeeManage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeManage);
        }

        // GET: EmployeeManages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeManage employeeManage = db.EmployeeManages.Find(id);
            if (employeeManage == null)
            {
                return HttpNotFound();
            }
            return View(employeeManage);
        }

        // POST: EmployeeManages/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,AGE,GENDER,PHONE,ADRESS")] EmployeeManage employeeManage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeManage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeManage);
        }

        // GET: EmployeeManages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeManage employeeManage = db.EmployeeManages.Find(id);
            if (employeeManage == null)
            {
                return HttpNotFound();
            }
            return View(employeeManage);
        }

        // POST: EmployeeManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeManage employeeManage = db.EmployeeManages.Find(id);
            db.EmployeeManages.Remove(employeeManage);
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
