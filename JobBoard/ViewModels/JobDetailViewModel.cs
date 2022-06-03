using System;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.ViewModels
{
    public class JobDetailViewModel
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string EmployerName { get; set; }
        public string Location { get; set; }
        public string RequiredSkills { get; set; }
        public string PreferredSkills { get; set;}

        public JobDetailViewModel(Job theJob)
        {
            JobId = theJob.Id;
            Name = theJob.Name;
            EmployerName = theJob.Employer.Name;
            Location = theJob.Location;
            RequiredSkills = theJob.RequiredSkills;
            PreferredSkills = theJob.PreferredSkills;
        }
    }
}