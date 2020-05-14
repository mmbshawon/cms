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
    public class DskillsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Dskills
        public ActionResult Index()
        {
            // var dskills = db.dskills.Include(d => d.DsCategory);
            // return View(dskills.ToList());
            AllSkillViewModels viewModel = new AllSkillViewModels();
            viewModel.DsCategories = db.dsCategories.ToList();//first table content
            viewModel.DmCategories = db.dmCategories.ToList(); //second table content
            viewModel.Dskills = db.dskills.ToList();
            return View(viewModel);
        }

        // GET: Dskills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dskill dskill = db.dskills.Find(id);
            if (dskill == null)
            {
                return HttpNotFound();
            }
            return View(dskill);
        }

        // GET: Dskills/Create
        public ActionResult Create()
        {
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName");
            ViewBag.DsCategoryId = defaultSelectListItems;
            return View();
        }

        public JsonResult GetDsCategory(int DmCategoryId)
        {
            var dsCategories = db.dsCategories.Where(x => x.DmCategoryId == DmCategoryId);
            var jsonResult = dsCategories.Select(c => new { c.Id, c.DsCategoryName, c.DmCategoryId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        // POST: Dskills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DskillName,DsCategoryId")] Dskill dskill)
        {
            if (ModelState.IsValid)
            {
                db.dskills.Add(dskill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DsCategoryId = new SelectList(db.dsCategories, "Id", "DsCategoryName", dskill.DsCategoryId);
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName");
            ViewBag.DsCategoryId = defaultSelectListItems;
            return View(dskill);
        }

        // GET: Dskills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dskill dskill = db.dskills.Find(id);
            if (dskill == null)
            {
                return HttpNotFound();
            }
            ViewBag.DsCategoryId = new SelectList(db.dsCategories, "Id", "DsCategoryName", dskill.DsCategoryId);
            return View(dskill);
        }

        // POST: Dskills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DskillName,DsCategoryId")] Dskill dskill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dskill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DsCategoryId = new SelectList(db.dsCategories, "Id", "DsCategoryName", dskill.DsCategoryId);
            return View(dskill);
        }

        // GET: Dskills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dskill dskill = db.dskills.Find(id);
            if (dskill == null)
            {
                return HttpNotFound();
            }
            return View(dskill);
        }

        // POST: Dskills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dskill dskill = db.dskills.Find(id);
            db.dskills.Remove(dskill);
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
