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
    public class PskillsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Pskills
        public ActionResult Index()
        {
            // var pskills = db.pskills.Include(p => p.PsCategory);
            // return View(pskills.ToList());

            AllSkillViewModels viewModel = new AllSkillViewModels();
            viewModel.psCategories = db.psCategories.ToList();//first table content
            viewModel.pmCategories = db.pmCategories.ToList(); //second table content
            viewModel.pskills = db.pskills.ToList();
            return View(viewModel);
        }

        // GET: Pskills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pskill pskill = db.pskills.Find(id);
            if (pskill == null)
            {
                return HttpNotFound();
            }
            return View(pskill);
        }

        // GET: Pskills/Create
        public ActionResult Create()
        {
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName");
            ViewBag.PsCategoryId = defaultSelectListItems;
            return View();
        }

        public JsonResult GetPsCategory(int PmCategoryId)
        {
            var psCategories = db.psCategories.Where(x => x.PmCategoryId == PmCategoryId);
            var jsonResult = psCategories.Select(c => new { c.Id, c.PsCategoryName, c.PmCategoryId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        // POST: Dskills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PskillName,PsCategoryId")] Pskill pskill)
        {
            if (ModelState.IsValid)
            {
                db.pskills.Add(pskill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DsCategoryId = new SelectList(db.dsCategories, "Id", "DsCategoryName", dskill.DsCategoryId);
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName");
            ViewBag.PsCategoryId = defaultSelectListItems;
            return View(pskill);
        }

        // GET: Pskills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pskill pskill = db.pskills.Find(id);
            if (pskill == null)
            {
                return HttpNotFound();
            }
            ViewBag.PsCategoryId = new SelectList(db.psCategories, "Id", "PsCategoryName", pskill.PsCategoryId);
            return View(pskill);
        }

        // POST: Pskills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PskillName,PsCategoryId")] Pskill pskill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pskill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PsCategoryId = new SelectList(db.psCategories, "Id", "PsCategoryName", pskill.PsCategoryId);
            return View(pskill);
        }

        // GET: Pskills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pskill pskill = db.pskills.Find(id);
            if (pskill == null)
            {
                return HttpNotFound();
            }
            return View(pskill);
        }

        // POST: Pskills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pskill pskill = db.pskills.Find(id);
            db.pskills.Remove(pskill);
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
