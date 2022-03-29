using AutoMapper;
using EntV.Data;
using EntV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MembersController : Controller
    {
        private readonly UserManager<Member> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public MembersController(UserManager<Member> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        // GET: MembersController
        public ActionResult Index()
        {
            var educationMembers = _userManager.GetUsersInRoleAsync("Education").Result.ToList();
            var educationRoleId = _roleManager.FindByNameAsync("Education").Result.Id;
            var educationMembersVM = _mapper.Map<List<MemberViewModel>>(educationMembers);
            foreach (var member in educationMembersVM)
            {
                member.Roles = "Education";
                member.RoleIds = educationRoleId;
            }
            var studentMembers = _userManager.GetUsersInRoleAsync("Student").Result.ToList();
            var studentRoleId = _roleManager.FindByNameAsync("Student").Result.Id;
            var studentMembersVM = _mapper.Map<List<MemberViewModel>>(studentMembers);
            foreach (var member in studentMembersVM)
            {
                member.Roles = "Student";
                member.RoleIds = studentRoleId;
            }
            List<MemberViewModel> data = educationMembersVM.Concat(studentMembersVM).ToList();
            return View(data);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                var member = _userManager.FindByIdAsync(id).Result;
                var roles = _userManager.GetRolesAsync(member).Result;
                string role = string.Empty;
                foreach (var rle in roles)
                {
                    role += rle;
                    role += " ";
                }
                var data = new MemberViewModel
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    MelliCode = member.MelliCode,
                    PhoneNumber = member.PhoneNumber,
                    Email = member.Email,
                    BirthDate = member.BirthDate,
                    JoinDate = member.JoinDate,
                    Roles = role
                };
                // The mapping below throws an error and is caught by the catch block. it is done manually above.
                //var data = _mapper.Map<MemberViewModel>(educationMember);
                return View(data);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View();
            }
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MembersController/Edit/5
        public ActionResult Edit(string id)
        {
            if (_userManager.FindByIdAsync(id).Result == null)
            {
                return NotFound();
            }
            var member = _userManager.FindByIdAsync(id).Result;
            var roles = _userManager.GetRolesAsync(member).Result;
            string role = string.Empty;
            foreach (var rle in roles)
            {
                role += rle;
                role += " ";
            }
            var data = _mapper.Map<MemberViewModel>(member);
            data.Roles = role;
            return View(data);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                var record = _userManager.FindByIdAsync(data.Id).Result;
                var roles = _userManager.GetRolesAsync(record).Result;
                // The lines below for adjusting the roles of a user raise an exception. fix it
                var roleAddSuccess = _userManager.AddToRolesAsync(record, new List<string> { data.Roles }).Result.Succeeded;
                if (roleAddSuccess)
                {
                    var roleRemoveSuccess = _userManager.RemoveFromRolesAsync(record, roles).Result.Succeeded;
                    roleAddSuccess = _userManager.AddToRolesAsync(record, new List<string> { data.Roles }).Result.Succeeded;
                }
                else
                {
                    ModelState.AddModelError("", "Could not find the given role");
                    return View(data);
                }
                record.FirstName = data.FirstName;
                record.LastName = data.LastName;
                record.MelliCode = data.MelliCode;
                record.PhoneNumber = data.PhoneNumber;
                record.Email = data.Email;
                record.BirthDate = data.BirthDate;
                data.JoinDate = data.JoinDate;
                var success = _userManager.UpdateAsync(record).Result.Succeeded;
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

        // GET: MembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembersController/Delete/5
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
