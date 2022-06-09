using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Employer Name"), Required]
        public string EmployerName { get; set; }
    }
}
