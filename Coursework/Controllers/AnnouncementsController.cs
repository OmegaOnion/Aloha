using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coursework.Models;
using Coursework.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Coursework.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly CourseworkContext _context;
        private readonly UserManager<User> _userManager;
        //takes Coursework context and user manage for database management 
        public AnnouncementsController(CourseworkContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Announcements.ToListAsync());
        }

        // GET: Announcements/Details/
        // gets announcement details and viewmodel
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcement announcement = await _context.Announcements.SingleOrDefaultAsync(m => m.Id == id);
           
            if (announcement == null)
            {
                return NotFound();
            }
            announcement.Views = announcement.Views + 1;
            await _context.SaveChangesAsync();
            AnnouncementDetailsViewModel vm = await GetAnnouncementDetailsViewModelByAnnouncement(announcement);
              

            return View(vm);
        }
        //POST
        // adds a new comment to the announcement
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([Bind("AnnouncementId","Message")] AnnouncementDetailsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();

                comment.Message = vm.Message;
                
                if (comment.Message == null)
                {
                    return NotFound();
                }
                Announcement announcement = await _context.Announcements.SingleOrDefaultAsync(m => m.Id == vm.AnnouncementId);

                if (announcement == null)
                {
                    return NotFound();
                }

              

                User user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                
                comment.FirstName = user.FirstName;
                comment.LastName = user.LastName;

                comment.MyAnnouncement = announcement;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                vm = await GetAnnouncementDetailsViewModelByAnnouncement(announcement);
            }
            return View(vm);
        }

        private async Task<AnnouncementDetailsViewModel> GetAnnouncementDetailsViewModelByAnnouncement(Announcement announcement)
        {
            AnnouncementDetailsViewModel vm = new AnnouncementDetailsViewModel();

            vm.Announcement = announcement;

            // get comments from DB
            List<Comment> comments = await _context.Comments.Where(x => x.MyAnnouncement == announcement).ToListAsync();

            vm.Comments = comments;

            return vm;
        }

        [Authorize(Roles = "Admin")]
        // GET: Announcements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Message,Views,Time")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }
        [Authorize(Roles = "Admin")]
        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.SingleOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Message,Views,Time")] Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcements.SingleOrDefaultAsync(m => m.Id == id);
            _context.Announcements.Remove(announcement);


            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}
