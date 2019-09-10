using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        // public virtual User MyUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Announcement"), Required]
        public virtual Announcement MyAnnouncement { get; set; }
        [Required, MinLength(3), MaxLength(300)]
        public string Message { get; set; }
        //public DateTime Time { get; set; }
    }
}
