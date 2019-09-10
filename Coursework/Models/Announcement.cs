using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3), MaxLength(100), Required]
        public string Title { get; set; }
        [MinLength(10), MaxLength(2000),Required]
        public string Message { get; set; }

        public int Views { get; set; }
        
        public DateTime Time { get; set; }
    }
}
