using AutoMapper;
using EntV.Data;
using EntV.Models;
using EntV.Repository;
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
    public class EnrollmentTypesController : Controller
    {
        private readonly IEnrollmentTypeRepository _repo;
        private readonly IMapper _mapper;
        public EnrollmentTypesController(IEnrollmentTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: EnrollmentTypesController
        public ActionResult Index()
        {
            var enrollmentType = _repo.FindAll().ToList();
            // The line below maps the data coming from the database to the view model
            var data = _mapper.Map<List<EnrollmentType>, List<EnrollmentTypeViewModel>>(enrollmentType);
            return View(data);
        }

        // GET: EnrollmentTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var enrollmentType = _repo.FindById(id);
            var data = _mapper.Map<EnrollmentTypeViewModel>(enrollmentType);
            return View(data);
        }

        // GET: EnrollmentTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnrollmentTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentTypeViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var enrollmentType = _mapper.Map<EnrollmentType>(data);
                var wasSuccessful = _repo.Create(enrollmentType);
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

        // GET: EnrollmentTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.Exists(id))
            {
                return NotFound();
            }
            var enrollmentType = _repo.FindById(id);
            var data = _mapper.Map<EnrollmentTypeViewModel>(enrollmentType);
            return View(data);
        }

        // POST: EnrollmentTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EnrollmentTypeViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var enrollmentType = _mapper.Map<EnrollmentType>(data);
                var success = _repo.Update(enrollmentType);
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

        // GET: EnrollmentTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            var enrollmentType = _repo.FindById(id);
            if (enrollmentType == null)
            {
                return NotFound();
            }
            var success = _repo.Delete(enrollmentType);
            if (!success)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        ////This section of code is for making sure the user wants to delete this section
        //// POST: EnrollmentTypesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, EnrollmentTypeViewModel data)
        //{
        //    try
        //    {
        //        var enrollmentType = _repo.FindById(id);
        //        if (enrollmentType == null)
        //        {
        //            return NotFound();
        //        }
        //        var success = _repo.Delete(enrollmentType);
        //        if (!success)
        //        {
        //            ModelState.AddModelError("", "Something went wrong.");
        //            return View(data);
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
