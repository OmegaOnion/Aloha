using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coursework.Models;
using Coursework.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coursework.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {

        private readonly CourseworkContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(CourseworkContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var vm = new UserManagementIndexViewModel
            {
                Users = _dbContext.Users.OrderBy(u => u.Email).Include(u => u.Roles).ToList()
            };

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var user = await GetUserById(id);
            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                UserId = id,
                Email = user.Email
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        {
            var user = await GetUserById(rvm.UserId);
            if (ModelState.IsValid)
            {
                
                var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            rvm.Roles = GetAllRoles();
            rvm.Email = user.Email;
            return View(rvm);
        }

        private async Task<User> GetUserById(String id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        /** returns list of roles*/
        private SelectList GetAllRoles()
        {
            return new SelectList(_roleManager.Roles.OrderBy(r => r.Name));
        }
    }
}
