using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using JobBoard.Data;
using Microsoft.EntityFrameworkCore;
using JobBoard.ViewModels;

namespace JobBoard.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext context;

        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"employer", "Employer"},
            {"location", "Location"}
        };

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            List<JobDetailViewModel> displayJobs = new List<JobDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs = context.Jobs
                   .Include(j => j.ApplicationUser)
                   .ToList();

                foreach (var job in jobs)
                {
                    JobDetailViewModel newDisplayJob = new JobDetailViewModel(job);
                    displayJobs.Add(newDisplayJob);
                }
            }
            else
            {
                if (searchType == "employer")
                {
                    jobs = context.Jobs
                        .Include(j => j.ApplicationUser)
                        .Where(j => j.ApplicationUser.EmployerName == searchTerm)
                        .ToList();

                    foreach (Job job in jobs)
                    {
                        JobDetailViewModel newDisplayJob = new JobDetailViewModel(job);
                        displayJobs.Add(newDisplayJob);
                    }

                }
                else if (searchType == "location")
                {
                    jobs = context.Jobs
                        .Include(j => j.ApplicationUser)
                        .Where(j => j.Location == searchTerm)
                        .ToList();

                    foreach (Job job in jobs)
                    {
                        JobDetailViewModel newDisplayJob = new JobDetailViewModel(job);
                        displayJobs.Add(newDisplayJob);
                    }
                }
            }

            ViewBag.columns = ColumnChoices;
            ViewBag.title = "Jobs with " + ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = displayJobs;

            return View("Index");
        }

        public IActionResult JobDetail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.ApplicationUser)
                .Single(j => j.Id == id);

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob);
            return View(viewModel);
        }
    }
}
