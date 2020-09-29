using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Data;
using EmployeesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Controllers
{
    public class EmployeeController : Controller
    {
        // using application context for database operations
        private readonly ApplicationDbContext _AppDb;
        // ctor
        public EmployeeController(ApplicationDbContext Db)
        {
            _AppDb = Db;
        }
        // action for Employees list
        public IActionResult EmployeeList()
        {
            try
            {
                // getting all the employees
                var empList = _AppDb.tblEmployee.ToList();
                return View(empList);

            }catch(Exception)
            {
                return View();
            }
        }
        // this actions handles both add and update ooperations of database table 
        public IActionResult Create(Employee emp)
        {
            return View(emp);
        }

        // Addemployee and update employee using this asynchronous action
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(emp.EmpId==0)
                    {

                        _AppDb.Add(emp);
                        await _AppDb.SaveChangesAsync();
                   
                    }else
                    {
                        _AppDb.Entry(emp).State = EntityState.Modified;
                        await _AppDb.SaveChangesAsync();
                    }
                    // redirect to employee list page view
                    return RedirectToAction("EmployeeList");
                }
                return View(emp);
            }
            catch (Exception)
            {
                return RedirectToAction("EmployeeList");
            }
        }
        // action method to delete employee record using application context
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var emp =await _AppDb.tblEmployee.FindAsync(id);
                if (emp != null)
                {
                    _AppDb.tblEmployee.Remove(emp);
                    await _AppDb.SaveChangesAsync();
                }
                // redirect to employee list view
                return RedirectToAction("EmployeeList");
            }
            catch (Exception)
            {

                return RedirectToAction("EmployeeList");
            }
        }
    }
}
