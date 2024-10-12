﻿using atelier1.Models.Repositories;
using atelier1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace atelier1.Controllers
{
    public class EmployeeController : Controller
    {


        readonly IRepository<Employee> employeeRepository;



        //injection de dépendance
        public EmployeeController(IRepository<Employee> empRepository)
        {

            employeeRepository = empRepository;

        }





        public ActionResult Search(string term)
        {

            var result = employeeRepository.Search(term);
            return View("Index", result);
        }
        // GET: EmployeeController

        public ActionResult Index()
        {
            var employees = employeeRepository.GetAll();





            ViewData["EmployeesCount"] = employees.Count();
            ViewData["SalaryAverage"] = employeeRepository.SalaryAverage();
            ViewData["MaxSalary"] = employeeRepository.MaxSalary();
            ViewData["HREmployeesCount"] = employeeRepository.HrEmployeesCount();

            return View(employees);
           
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = employeeRepository.FindByID(id);
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeeRepository.FindByID(id);

            return View(employee);
        }
            // POST: EmployeeController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
              
                employeeRepository.Update(id, employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                employeeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
