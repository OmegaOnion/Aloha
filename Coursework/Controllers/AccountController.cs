using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coursework.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Coursework.Models;
using Microsoft.AspNetCore.Owin;
using Microsoft.AspNetCore.Http.Authentication;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coursework.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly CourseworkContext _context;



        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager,
            CourseworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            SeedUser();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.Remember, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Login Failed");
                return View(vm);
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = vm.Email, Email = vm.Email, FirstName = vm.FirstName, LastName = vm.LastName };
                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    await _signInManager.SignInAsync(user, false);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                //var roleStore = new RoleStore<IdentityRole>(_context);
                //var roleManager = new RoleManager<IdentityRole>(roleStore);

                //var userStore = new UserStore<User>(_context);
                //var userManager = new UserManager<User>(userStore);
                


                return View(vm);
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async void SeedUser()
        {
            var user = new User
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com",
                FirstName = "Member",
                LastName = "1",
            };


            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "password");
                // user.PasswordHash = hashed;
                await _userManager.CreateAsync(user, "password");
                await _userManager.AddToRoleAsync(user, "Admin");

            }
            var user2 = new User
            {
                UserName = "Customer1@email.com",
                Email = "Customer1@email.com",
                FirstName = "Customer",
                LastName = "1",
            };


            if (!_context.Users.Any(u => u.UserName == user2.UserName))
            {

                await _userManager.CreateAsync(user2, "password");
                await _userManager.AddToRoleAsync(user2, "Member");

            }

            var user3 = new User
            {
                UserName = "Customer2@email.com",
                Email = "Customer2@email.com",
                FirstName = "Customer",
                LastName = "2",
            };


            if (!_context.Users.Any(u => u.UserName == user3.UserName))
            {

                await _userManager.CreateAsync(user3, "password");
                await _userManager.AddToRoleAsync(user3, "Member");

            }
            var user4 = new User
            {
                UserName = "Customer3@email.com",
                Email = "Customer3@email.com",
                FirstName = "Customer",
                LastName = "3",
            };


            if (!_context.Users.Any(u => u.UserName == user4.UserName))
            {

                await _userManager.CreateAsync(user4, "password");
                await _userManager.AddToRoleAsync(user4, "Member");

            }
            var user5 = new User
            {
                UserName = "Customer4@email.com",
                Email = "Customer4@email.com",
                FirstName = "Customer",
                LastName = "4",
            };


            if (!_context.Users.Any(u => u.UserName == user5.UserName))
            {

                await _userManager.CreateAsync(user5, "password");
                await _userManager.AddToRoleAsync(user5, "Member");

            }
            var user6 = new User
            {
                UserName = "Customer5@email.com",
                Email = "Customer5@email.com",
                FirstName = "Customer",
                LastName = "5",
            };


            if (!_context.Users.Any(u => u.UserName == user6.UserName))
            {

                await _userManager.CreateAsync(user6, "password");
                await _userManager.AddToRoleAsync(user6, "Member");

            }
        }


    }
}
