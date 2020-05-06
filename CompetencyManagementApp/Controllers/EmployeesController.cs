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
    public class EmployeesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.Department).Include(e => e.EmployeeStatus).Include(e => e.Position);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName");
            ViewBag.EmployeeStatusId = new SelectList(db.employeeStatuses, "Id", "StatusName");
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeName,EmpoloyeeJoiningDate,EmployeeStatusId,EmpoloyeeEmail,EmpoloyeeUserName,EmpoloyeePassword,DepartmentId,PositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.EmployeeStatusId = new SelectList(db.employeeStatuses, "Id", "StatusName", employee.EmployeeStatusId);
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.EmployeeStatusId = new SelectList(db.employeeStatuses, "Id", "StatusName", employee.EmployeeStatusId);
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName", employee.PositionId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeName,EmpoloyeeJoiningDate,EmployeeStatusId,EmpoloyeeEmail,EmpoloyeeUserName,EmpoloyeePassword,DepartmentId,PositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.EmployeeStatusId = new SelectList(db.employeeStatuses, "Id", "StatusName", employee.EmployeeStatusId);
            ViewBag.PositionId = new SelectList(db.positions, "Id", "PositionName", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
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
