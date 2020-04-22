using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompetencyManagement.DataContext;
using CompetencyManagement.Model;

namespace CompetencyManagementApp.Controllers
{
    public class DmCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DmCategories
        public ActionResult Index()
        {
            return View(db.dmCategories.ToList());
        }

        // GET: DmCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DmCategory dmCategory = db.dmCategories.Find(id);
            if (dmCategory == null)
            {
                return HttpNotFound();
            }
            return View(dmCategory);
        }

        // GET: DmCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DmCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DmCategoryName")] DmCategory dmCategory)
        {
            if (ModelState.IsValid)
            {
                db.dmCategories.Add(dmCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dmCategory);
        }

        // GET: DmCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DmCategory dmCategory = db.dmCategories.Find(id);
            if (dmCategory == null)
            {
                return HttpNotFound();
            }
            return View(dmCategory);
        }

        // POST: DmCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DmCategoryName")] DmCategory dmCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dmCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dmCategory);
        }

        // GET: DmCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DmCategory dmCategory = db.dmCategories.Find(id);
            if (dmCategory == null)
            {
                return HttpNotFound();
            }
            return View(dmCategory);
        }

        // POST: DmCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DmCategory dmCategory = db.dmCategories.Find(id);
            db.dmCategories.Remove(dmCategory);
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
