using AutoMapper;
using EntV.Data;
using EntV.Models;
using EntV.Repository;
using EntV.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _repo;
        private readonly IDepartmentRepository _depRepo;
        private readonly IEnrollmentTypeRepository _enRepo;
        private readonly IMapper _mapper;
        public StudentsController(IStudentRepository repo, IDepartmentRepository depReo, IEnrollmentTypeRepository enRepo, IMapper mapper)
        {
            _repo = repo;
            _depRepo = depReo;
            _enRepo = enRepo;
            _mapper = mapper;
        }
        // GET: StudentsController
        public ActionResult Index()
        {
            var student = _repo.FindAll().ToList();
            // The line below maps the data coming from the database to the view model
            var data = _mapper.Map<List<Student>, List<StudentViewModel>>(student);
            return View(data);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var student = _repo.FindById(id);
            var data = _mapper.Map<StudentViewModel>(student);
            var depName = _depRepo.FindById(data.DepartmentId);
            var enrType = _enRepo.FindById(data.EnrollmentTypeId);
            data.DepartmentName = depName.DepartmentName;
            data.EnrollmentTypeName = enrType.EnrollmentTypeName;
            return View(data);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                string departmentIdHolder = data.DepartmentId.ToString().PadLeft(2, '0');
                int studentCount = _repo.Count(data.EntranceDate, data.DepartmentId) + 1;
                data.StudentId = data.EntranceDate.PadLeft(2, '0') + departmentIdHolder + studentCount.ToString().PadLeft(3, '0');
                var student = _mapper.Map<Student>(data);
                // Cannot add the student object into the database due to non-automatic id generation. Fix this.
                var wasSuccessful = _repo.Create(student);
                if (!wasSuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(data);
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var student = _repo.FindById(id);
            var data = _mapper.Map<StudentViewModel>(student);
            return View(data);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }                
                var student = _mapper.Map<Student>(data);
                var success = _repo.Update(student);
                if (!success)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(data);
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _repo.FindById(id);
            if (student == null)
            {
                return NotFound();
            }
            var success = _repo.Delete(student);
            if (!success)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
