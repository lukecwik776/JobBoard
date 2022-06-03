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

        public JobDetailViewModel(Job theJob, List<string> reqSkills, List<string> prefSkills)
        {
            JobId = theJob.Id;
            Name = theJob.Name;
            EmployerName = theJob.Employer.Name;
            Location = theJob.Location;

            RequiredSkills = "";
            for (int i = 0; i < reqSkills.Count; i++)
            {
                RequiredSkills += reqSkills[i];
                if (i < reqSkills.Count - 1)
                {
                    RequiredSkills += ", ";
                }
            }

            PreferredSkills = "";
            for (int i = 0; i < prefSkills.Count; i++)
            {
                PreferredSkills += prefSkills[i];
                if (i < prefSkills.Count - 1)
                {
                    PreferredSkills += ", ";
                }
            }
        }
    }
}