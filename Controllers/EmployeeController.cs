﻿using EmployeeManegmentSystem.Models;
using EmployeeManegmentSystem.View_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.Controllers
{
    //[Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public EmployeeController(IEmployeeRepository employeeRepository ,
                                   IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Employees
        //[Route("")]
        //[Route("Index")]
        //[Route("~//")]
        public ViewResult Index()
        {
            ViewBag.Pagedetails = "All Employees Details";

            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        // GET: Employee/Details/5
        //[Route("/employee/details/{id?}")]
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
        //[Route("/employee/create")]
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Tittle = "create employee";
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = null;
                if (model.Photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath , "images"); // to save in webroot/images
                    uniqeFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;//unique files name
                    string filePath = Path.Combine(uploadFolder, uniqeFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newemp = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqeFileName

                };
                _employeeRepository.Add(newemp);
                return RedirectToAction("Details", new { id = newemp.Id });
            }

            return View();

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
