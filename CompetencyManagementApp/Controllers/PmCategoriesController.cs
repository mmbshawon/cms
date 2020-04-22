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
    public class PmCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PmCategories
        public ActionResult Index()
        {
            return View(db.pmCategories.ToList());
        }

        // GET: PmCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PmCategory pmCategory = db.pmCategories.Find(id);
            if (pmCategory == null)
            {
                return HttpNotFound();
            }
            return View(pmCategory);
        }

        // GET: PmCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PmCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PmCategoryName")] PmCategory pmCategory)
        {
            if (ModelState.IsValid)
            {
                db.pmCategories.Add(pmCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pmCategory);
        }

        // GET: PmCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PmCategory pmCategory = db.pmCategories.Find(id);
            if (pmCategory == null)
            {
                return HttpNotFound();
            }
            return View(pmCategory);
        }

        // POST: PmCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PmCategoryName")] PmCategory pmCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pmCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pmCategory);
        }

        // GET: PmCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PmCategory pmCategory = db.pmCategories.Find(id);
            if (pmCategory == null)
            {
                return HttpNotFound();
            }
            return View(pmCategory);
        }

        // POST: PmCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PmCategory pmCategory = db.pmCategories.Find(id);
            db.pmCategories.Remove(pmCategory);
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
