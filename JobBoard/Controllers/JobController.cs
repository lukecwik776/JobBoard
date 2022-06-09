using JobBoard.Models;
using JobBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Data;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Web;
using System.Threading.Tasks;

namespace JobBoard.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private ApplicationDbContext context;

        private UserManager<ApplicationUser> _userManager; 
        public JobController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View("AddJob");
        }

        public async Task<IActionResult> AddJob()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            AddJobViewModel jobViewModel = new AddJobViewModel();
            jobViewModel.EmployerName = user.EmployerName;
            return View(jobViewModel);
        }

        [HttpPost]
        //[Route("/add")]
        public async Task<IActionResult> ProcessAddJobForm(AddJobViewModel addJobViewModel)
        {

            if (ModelState.IsValid)
            {
              

                ApplicationUser user = await _userManager.GetUserAsync(User);
                
                Job newJob = new Job
                {
                    Name = addJobViewModel.JobTitle,
                    Location = addJobViewModel.JobLocation, 
                    Description = addJobViewModel.JobDescription,
                    ApplicationUser = user,
                    PayRate = addJobViewModel.PayRate,
                    RequiredSkills = addJobViewModel.RequiredSkills,
                    PreferredSkills = addJobViewModel.PreferredSkills
                };

                context.Jobs.Add(newJob);
                context.SaveChanges();
                return Redirect("JobPosted");
            }
            return View("AddJob", addJobViewModel);
        }

        public IActionResult JobPosted()
        {
            return View();
        }

    }
}
