using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMVC.Data;
using CrudMVC.Models;

namespace CrudMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _db;

        public StudentsController(StudentContext db)
        {
            _db = db;
        }
        public IActionResult StudentsList()
        {
            try
            {
                //var stdList = _db.tblStudents.ToList();

                var stdList = from a in _db.tblStudents
                              join b in _db.tblDepartments
                              on a.DepartmentID equals b.ID into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Students
                              {
                                  ID = a.ID,
                                  Name = a.Name,
                                  FatherName = a.FatherName,
                                  Email = a.Email,
                                  Mobile = a.Mobile,
                                  Description = a.Description,
                                  DepartmentID = a.DepartmentID,
                                  Department = b == null ? "" : b.Name
                              };
                return View(stdList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult AddStudent()
        {
            loadDDL();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>AddStudent(Students obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    _db.tblStudents.Add(obj);
                    await _db.SaveChangesAsync();
                  
                    return RedirectToAction("StudentsList");
                }
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("StudentsList");
            }
        }

        private void loadDDL()
        {
            try
            {
                List<Departments> deptList = new List<Departments>();

                deptList = _db.tblDepartments.ToList();

                //deptList.Insert(0, new Departments { ID = 0, Name = "Please Select" });
                
                ViewBag.DeptList = deptList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
