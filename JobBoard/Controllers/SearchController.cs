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
                   .Include(j => j.Employer)
                   .ToList();

                foreach (var job in jobs)
                {
                    List<string> reqSkills = job.RequiredSkills;
                    List<string> prefSkills = job.PreferredSkills;

                    JobDetailViewModel newDisplayJob = new JobDetailViewModel(job, reqSkills, prefSkills);
                    displayJobs.Add(newDisplayJob);
                }
            }
            else
            {
                if (searchType == "employer")
                {
                    jobs = context.Jobs
                        .Include(j => j.Employer)
                        .Where(j => j.Employer.Name == searchTerm)
                        .ToList();

                    foreach (Job job in jobs)
                    {
                        List<string> reqSkills = job.RequiredSkills;
                        List<string> prefSkills = job.PreferredSkills;

                        JobDetailViewModel newDisplayJob = new JobDetailViewModel(job, reqSkills, prefSkills);
                        displayJobs.Add(newDisplayJob);
                    }

                }
                else if (searchType == "location")
                {
                    List<Job> searchJobs = context.Jobs
                        .Where(j => j.Location == searchTerm)
                        .Include(j => j.Location)
                        .ToList();

                    foreach (var job in searchJobs)
                    {
                        Job foundJob = context.Jobs
                            .Include(j => j.Employer)
                            .Single(j => j.Id == job.Id);

                        List<string> reqSkills = job.RequiredSkills;
                        List<string> prefSkills = job.PreferredSkills;

                        JobDetailViewModel newDisplayJob = new JobDetailViewModel(foundJob, reqSkills, prefSkills);
                        displayJobs.Add(newDisplayJob);
                    }
                }
            }

            ViewBag.columns = ColumnChoices;
            ViewBag.title = "Jobs with " + ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = displayJobs;

            return View("Index");
        }
    }
}
