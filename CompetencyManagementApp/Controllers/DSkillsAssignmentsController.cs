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
    public class DSkillsAssignmentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DSkillsAssignments
        public ActionResult Index()
        {
            //var dSkillsAssignments = db.dSkillsAssignments.Include(d => d.Department).Include(d => d.Dskill);
            //return View(dSkillsAssignments.ToList());
            AllSkillViewModels viewModel = new AllSkillViewModels();
            viewModel.Departments = db.departments.ToList();
            viewModel.DsCategories = db.dsCategories.ToList();//first table content
            viewModel.DmCategories = db.dmCategories.ToList(); //second table content
            viewModel.Dskills = db.dskills.ToList();
            viewModel.dSkillsAssignments = db.dSkillsAssignments.Include(d => d.Department).Include(d => d.Dskill).ToList();
            return View(viewModel);
        }

        // GET: DSkillsAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSkillsAssignment dSkillsAssignment = db.dSkillsAssignments.Find(id);
            if (dSkillsAssignment == null)
            {
                return HttpNotFound();
            }
            return View(dSkillsAssignment);
        }

        // GET: DSkillsAssignments/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName");

            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName");

            //ViewBag.DskillId = new SelectList(db.dskills, "Id", "DskillName");

            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };

            ViewBag.DsCategoryId = defaultSelectListItems;
            ViewBag.DskillId = defaultSelectListItems;
            return View();
        }

        // POST: DSkillsAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,DskillId")] DSkillsAssignment dSkillsAssignment)
        {
            if (ModelState.IsValid)
            {
                db.dSkillsAssignments.Add(dSkillsAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName");

            ViewBag.DmCategoryId = new SelectList(db.dmCategories, "Id", "DmCategoryName");

            //ViewBag.DskillId = new SelectList(db.dskills, "Id", "DskillName");

            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };

            ViewBag.DsCategoryId = defaultSelectListItems;
            ViewBag.DskillId = defaultSelectListItems;
            return View(dSkillsAssignment);
        }



        public JsonResult GetDsCategory(int dmCategoryId)
        {
            var dsCategory = db.dsCategories.Where(x => x.DmCategoryId == dmCategoryId);
            var jsonResult = dsCategory.Select(c => new { c.Id, c.DsCategoryName, c.DmCategoryId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDskill(int dsCategoryId)
        {
            var Dskill = db.dskills.Where(c => c.DsCategoryId == dsCategoryId);
            var jsonResult = Dskill.Select(c => new { c.Id, c.DskillName, c.DsCategoryId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        // GET: DSkillsAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSkillsAssignment dSkillsAssignment = db.dSkillsAssignments.Find(id);
            if (dSkillsAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName", dSkillsAssignment.DepartmentId);
            ViewBag.DskillId = new SelectList(db.dskills, "Id", "DskillName", dSkillsAssignment.DskillId);
            return View(dSkillsAssignment);
        }


        // POST: DSkillsAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentId,DskillId")] DSkillsAssignment dSkillsAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSkillsAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName", dSkillsAssignment.DepartmentId);
            ViewBag.DskillId = new SelectList(db.dskills, "Id", "DskillName", dSkillsAssignment.DskillId);
            return View(dSkillsAssignment);
        }

        // GET: DSkillsAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSkillsAssignment dSkillsAssignment = db.dSkillsAssignments.Find(id);
            if (dSkillsAssignment == null)
            {
                return HttpNotFound();
            }
            return View(dSkillsAssignment);
        }

        // POST: DSkillsAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DSkillsAssignment dSkillsAssignment = db.dSkillsAssignments.Find(id);
            db.dSkillsAssignments.Remove(dSkillsAssignment);
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
