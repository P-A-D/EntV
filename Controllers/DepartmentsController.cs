using AutoMapper;
using EntV.Data;
using EntV.Models;
using EntV.Repository;
using EntV.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;
        public DepartmentsController(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: DepartmentsController
        public ActionResult Index()
        {
            var departments = _repo.FindAll().ToList();
            // The line below maps the data coming from the database to the view model
            var data = _mapper.Map<List<Department>, List<DepartmentViewModel>>(departments);
            return View(data);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var department = _repo.FindById(id);
            var data = _mapper.Map<DepartmentViewModel>(department);
            return View(data);
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var department = _mapper.Map<Department>(data);
                var wasSuccessful = _repo.Create(department);
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

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var department = _repo.FindById(id);
            var data = _mapper.Map<DepartmentViewModel>(department);
            return View(data);
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var department = _mapper.Map<Department>(data);
                var success = _repo.Update(department);
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

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = _repo.FindById(id);
            if (department == null)
            {
                return NotFound();
            }
            var success = _repo.Delete(department);
            if (!success)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
        ////This section of code is for making sure the user wants to delete this section
        //// POST: DepartmentsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
