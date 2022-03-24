using AutoMapper;
using EntV.Data;
using EntV.Models;
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
    [Authorize(Roles = "Student, Education")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _repo;
        private readonly IDepartmentRepository _fkrepo;
        private readonly IMapper _mapper;
        public CoursesController(ICourseRepository repo, IDepartmentRepository fkrepo, IMapper mapper)
        {
            _repo = repo;
            _fkrepo = fkrepo;
            _mapper = mapper;
        }
        // GET: CoursesController
        public ActionResult Index()
        {
            var course = _repo.FindAll().ToList();
            // The line below maps the data coming from the database to the view model
            var data = _mapper.Map<List<Course>, List<CourseViewModel>>(course);
            return View(data);
        }

        // GET: CoursesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var course = _repo.FindById(id);
            var fkData = _fkrepo.FindById(course.DepartmentId);
            //var fkDataVM = _mapper.Map<DepartmentViewModel>(fkData);
            var data = _mapper.Map<CourseViewModel>(course);
            data.DepartmentName = fkData.DepartmentName;
            return View(data);
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var course = _mapper.Map<Course>(data);
                var wasSuccessful = _repo.Create(course);
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

        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var course = _repo.FindById(id);
            var data = _mapper.Map<CourseViewModel>(course);
            return View(data);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var course = _mapper.Map<Course>(data);
                var success = _repo.Update(course);
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

        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = _repo.FindById(id);
            if (course == null)
            {
                return NotFound();
            }
            var success = _repo.Delete(course);
            if (!success)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
