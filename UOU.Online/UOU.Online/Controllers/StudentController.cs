using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UOU.Online.BusinessLayer.Repository;
using UOU.Online.BusinessLayer.Models;

namespace UOU.Online.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepo;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepo = studentRepository;
        }
        // GET: Student
        public ActionResult Index()
        {
            var students=studentRepo.GetStudents();
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Student s)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (studentRepo.AddStudent(s)>0)
                    {
                        ViewBag.Message = "Student added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}