using Coursework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.Configuration
{
    public class MemberSeed
    {

        //private readonly CourseworkContext _context;
        //private readonly UserManager<User> _userManager;
        public MemberSeed(CourseworkContext context, UserManager<User> userManager)
        {

            //_context = context;


            var user = new User
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com",
                FirstName = "Member",
                LastName = "1",
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {

                userManager.CreateAsync(user, "password");
                userManager.AddToRoleAsync(user, "Admin");
            }
                //var password = new PasswordHasher<User>();
                //var hashed = password.HashPassword(user, "password");

                // context.Users.Add(user);
                //await context.SaveChangesAsync();


                //Seed();
            }
        public async void Seed()
        {
           // var user = new User { UserName = "Member1@email.com", Email = "Member1@email.com", FirstName = "Member", LastName = "1" };
            var user = new User
            {
                UserName = "Member1@email.com",
               // NormalizedUserName = "Member1@email.com",
                Email = "Member1@email.com",
                //NormalizedEmail = "Member1@email.com",
                FirstName = "Member",
                LastName="1",
               // EmailConfirmed = true,
               // LockoutEnabled = false,
              //  SecurityStamp = Guid.NewGuid().ToString()
            };

            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "password");

            //var password = new PasswordHasher<User>();
            //var hashed = password.HashPassword(user, "password");
            //user.PasswordHash = hashed;
            //var userStore = new UserStore<User>(_context);
            //await userStore.CreateAsync(user);
            // await userStore.AddToRoleAsync(user, "Admin");
            //_context.Users.Add(user);
           // await _context.SaveChangesAsync();

            //if (!_context.Users.Any(u => u.UserName == user.UserName))
            //{
            //var password = new PasswordHasher<User>();
            //var hashed = password.HashPassword(user, "password");
            // user.PasswordHash = hashed;
            // var userStore = new UserStore<User>(_context);
            //await userStore.CreateAsync(user);
            // await userStore.AddToRoleAsync(user, "Admin");
            //}

            // await _context.SaveChangesAsync();
            // await _userManager.AddToRoleAsync(user, "Member");

        }

    }
}
