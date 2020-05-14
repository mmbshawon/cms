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
    public class PSkillsAssignmentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PSkillsAssignments
        public ActionResult Index()
        {
            // var pSkillsAssignments = db.pSkillsAssignments.Include(p => p.Position).Include(p => p.Pskill);
            // return View(pSkillsAssignments.ToList());

            AllSkillViewModels viewModel = new AllSkillViewModels();
            viewModel.Positions = db.positions.ToList();
            viewModel.psCategories = db.psCategories.ToList();//first table content
            viewModel.pmCategories = db.pmCategories.ToList(); //second table content
            viewModel.pskills = db.pskills.ToList();
            viewModel.pSkillsAssignments = db.pSkillsAssignments.Include(d => d.Position).Include(d => d.Pskill).ToList();

            return View(viewModel);
        }

        // GET: PSkillsAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSkillsAssignment pSkillsAssignment = db.pSkillsAssignments.Find(id);
            if (pSkillsAssignment == null)
            {
                return HttpNotFound();
            }
            return View(pSkillsAssignment);
        }

        // GET: PSkillsAssignments/Create
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName");

            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName");

            //ViewBag.DskillId = new SelectList(db.dskills, "Id", "DskillName");

            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };

            ViewBag.PsCategoryId = defaultSelectListItems;
            ViewBag.PskillId = defaultSelectListItems;
            return View();
        }

        // POST: DSkillsAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PositionId,PskillId")] PSkillsAssignment pSkillsAssignment)
        {
            if (ModelState.IsValid)
            {
                db.pSkillsAssignments.Add(pSkillsAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName");

            ViewBag.PmCategoryId = new SelectList(db.pmCategories, "Id", "PmCategoryName");

            //ViewBag.DskillId = new SelectList(db.dskills, "Id", "DskillName");

            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };

            ViewBag.PsCategoryId = defaultSelectListItems;
            ViewBag.PskillId = defaultSelectListItems;
            return View(pSkillsAssignment);
        }



        public JsonResult GetPsCategory(int pmCategoryId)
        {
            var psCategory = db.psCategories.Where(x => x.PmCategoryId == pmCategoryId);
            var jsonResult = psCategory.Select(c => new { c.Id, c.PsCategoryName, c.PmCategoryId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPskill(int psCategoryId)
        {
            var Pskill = db.pskills.Where(c => c.PsCategoryId == psCategoryId);
            var jsonResult = Pskill.Select(c => new { c.Id, c.PskillName, c.PsCategoryId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        // GET: PSkillsAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSkillsAssignment pSkillsAssignment = db.pSkillsAssignments.Find(id);
            if (pSkillsAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName", pSkillsAssignment.PositionId);
            ViewBag.PskillId = new SelectList(db.pskills, "Id", "PskillName", pSkillsAssignment.PskillId);
            return View(pSkillsAssignment);
        }

        // POST: PSkillsAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PositionId,PskillId")] PSkillsAssignment pSkillsAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSkillsAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName", pSkillsAssignment.PositionId);
            ViewBag.PskillId = new SelectList(db.pskills, "Id", "PskillName", pSkillsAssignment.PskillId);
            return View(pSkillsAssignment);
        }

        // GET: PSkillsAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSkillsAssignment pSkillsAssignment = db.pSkillsAssignments.Find(id);
            if (pSkillsAssignment == null)
            {
                return HttpNotFound();
            }
            return View(pSkillsAssignment);
        }

        // POST: PSkillsAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PSkillsAssignment pSkillsAssignment = db.pSkillsAssignments.Find(id);
            db.pSkillsAssignments.Remove(pSkillsAssignment);
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
