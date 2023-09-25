using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpBusiness emp;
        public EmpController(IEmpBusiness emp)
        {
            this.emp = emp;
        }
        public IActionResult Index()
        {
           List<Empmodel> list = new List<Empmodel>();
            list=emp.GetAllEmployees().ToList();
            return View(list);
            
        }
        [HttpGet]
        //[Route("AddEmp")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Empmodel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emp.AddEmpData(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch 
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                return View(emp.GetEmployeeById(id));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, Empmodel employee)
        {
            try
            {
                if (id != employee.Emp_Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    emp.UpdateEmp(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Empmodel empmodel = emp.GetEmployeeById(id);
            if(id!=null&&empmodel!=null)
            {
                return View(empmodel);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
           if(id!=null)
            {
                emp.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("Emp/UserData")]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var result= empBusiness.GetAllEmployees();
            //var employee = result.FirstOrDefault(x=>x.EmployeeId == employeeId);
            var employee = emp.GetEmployeeById(id);
            ViewBag.Message = "Data Fetched Successfully".ToString();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Profile()
        {
            int id = (int)HttpContext.Session.GetInt32("EmpId");
            if (id == null)
            {
                return NotFound();
            }
            //var result= empBusiness.GetAllEmployees();
            //var employee = result.FirstOrDefault(x=>x.EmployeeId == employeeId);
            var employee = emp.GetEmployeeById(id);
            ViewBag.Message = "Data Fetched Successfully".ToString();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        //Login Employee
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(EmpLoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = emp.LoginEmployee(model);
                    if (result != null)
                    {
                        HttpContext.Session.SetInt32("EmpId", result.Emp_Id);
                        HttpContext.Session.SetString("EmpName", result.Employee_Name);
                        return RedirectToAction("Profile");
                    }
                    return NotFound();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ReviewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    emp.AddReview(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
