using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.Models
{
    public class User : IdentityUser
    {       
        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }
        
    }
}
