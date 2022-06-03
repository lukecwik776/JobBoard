using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JobBoard.Models;

namespace JobBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employer> Employers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
