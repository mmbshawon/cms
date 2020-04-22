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
    public class DsCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DsCategories
        public ActionResult Index()
        {
            var dsCategories = db.dsCategories.Include(d => d.DmCategory);
            return View(dsCategories.ToList());
        }

        // GET: DsCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DsCategory dsCategory = db.dsCategories.Find(id);
            if (dsCategory == null)
            {
                return HttpNotFound();
            }
            return View(dsCategory);
        }

        // GET: DsCategories/Create
        public ActionResult Create()
        {
            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName");
            return View();
        }

        // POST: DsCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DsCategoryName,DmCategoryId")] DsCategory dsCategory)
        {
            if (ModelState.IsValid)
            {
                db.dsCategories.Add(dsCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName", dsCategory.DmCategoryId);
            return View(dsCategory);
        }

        // GET: DsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DsCategory dsCategory = db.dsCategories.Find(id);
            if (dsCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName", dsCategory.DmCategoryId);
            return View(dsCategory);
        }

        // POST: DsCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DsCategoryName,DmCategoryId")] DsCategory dsCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dsCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName", dsCategory.DmCategoryId);
            return View(dsCategory);
        }

        // GET: DsCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DsCategory dsCategory = db.dsCategories.Find(id);
            if (dsCategory == null)
            {
                return HttpNotFound();
            }
            return View(dsCategory);
        }

        // POST: DsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DsCategory dsCategory = db.dsCategories.Find(id);
            db.dsCategories.Remove(dsCategory);
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
