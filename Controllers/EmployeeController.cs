using EmployeeManegmentSystem.Models;
using EmployeeManegmentSystem.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: Employees
        [Route("")]
        [Route("Index")]
        [Route("~//")]
        public ViewResult Index()
        {
            ViewBag.Pagedetails = "All Employees Details";

            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        // GET: Employee/Details/5
        [Route("/employee/details/{id?}")]
        public ViewResult Details(int? id)
        {
            EmployeeDetailsVM employeeVM = new EmployeeDetailsVM()
            {
                Employee= _employeeRepository.GetEmployee(id??1),
                PageTitle= "Employee Details"
            };
            //Employee model = _employeeRepository.GetEmployee(id);
            //ViewBag.Employee = model;
            //ViewBag.pagedetails = "Employee Details";
            return View (employeeVM);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
