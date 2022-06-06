using JobBoard.Models;
using JobBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Data;

namespace JobBoard.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private ApplicationDbContext context;

        public JobController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View("AddJob");
        }

        public IActionResult AddJob()
        {
            AddJobViewModel jobViewModel = new AddJobViewModel();
            return View(jobViewModel);
        }

        [HttpPost]
        //[Route("/add")]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Job newJob = new Job()
                {
                    Name = addJobViewModel.JobTitle,
                    Location = addJobViewModel.JobLocation, 
                    Description = addJobViewModel.JobDescription
                };

                context.Jobs.Add(newJob);
                context.SaveChanges();
                return Redirect("/JobPosted");
            }
            return View("AddJob", addJobViewModel);
        }

        public IActionResult JobPosted()
        {
            return View();
        }

    }
}
