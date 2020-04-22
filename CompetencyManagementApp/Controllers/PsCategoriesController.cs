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
    public class PsCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PsCategories
        public ActionResult Index()
        {
            var psCategories = db.psCategories.Include(p => p.PmCategory);
            return View(psCategories.ToList());
        }

        // GET: PsCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PsCategory psCategory = db.psCategories.Find(id);
            if (psCategory == null)
            {
                return HttpNotFound();
            }
            return View(psCategory);
        }

        // GET: PsCategories/Create
        public ActionResult Create()
        {
            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName");
            return View();
        }

        // POST: PsCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PsCategoryName,PmCategoryId")] PsCategory psCategory)
        {
            if (ModelState.IsValid)
            {
                db.psCategories.Add(psCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName", psCategory.PmCategoryId);
            return View(psCategory);
        }

        // GET: PsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PsCategory psCategory = db.psCategories.Find(id);
            if (psCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName", psCategory.PmCategoryId);
            return View(psCategory);
        }

        // POST: PsCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PsCategoryName,PmCategoryId")] PsCategory psCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(psCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName", psCategory.PmCategoryId);
            return View(psCategory);
        }

        // GET: PsCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PsCategory psCategory = db.psCategories.Find(id);
            if (psCategory == null)
            {
                return HttpNotFound();
            }
            return View(psCategory);
        }

        // POST: PsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PsCategory psCategory = db.psCategories.Find(id);
            db.psCategories.Remove(psCategory);
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
