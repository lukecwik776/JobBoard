using System;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.ViewModels
{
    public class JobDetailViewModel
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EmployerName { get; set; }
        public string Location { get; set; }
        public string RequiredSkills { get; set; }
        public string PreferredSkills { get; set;}
        public string PayRate { get; set; }

        public JobDetailViewModel(Job theJob)
        {
            JobId = theJob.Id;
            Name = theJob.Name;
            Description = theJob.Description;
            EmployerName = theJob.ApplicationUser.EmployerName;
            Location = theJob.Location;
            RequiredSkills = theJob.RequiredSkills;
            PreferredSkills = theJob.PreferredSkills;
            PayRate = theJob.PayRate;
        }
    }
}