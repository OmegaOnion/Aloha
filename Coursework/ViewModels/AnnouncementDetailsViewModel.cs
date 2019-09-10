using Coursework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.ViewModels
{
    public class AnnouncementDetailsViewModel
    {
        public Announcement Announcement { get; set; }
        public List<Comment> Comments { get; set; }
        public int AnnouncementId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
