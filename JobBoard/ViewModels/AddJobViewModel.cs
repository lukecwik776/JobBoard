using JobBoard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace JobBoard.ViewModels
{
    public class AddJobViewModel
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public string EmployerName { get; set; }
        public string PayRate { get; set; }
        public string RequiredSkills { get; set; }
        public string PreferredSkills { get; set; }

        public AddJobViewModel(Job theJob)
        {
            //JobTitle = theJob.Name;
            //JobDescription = theJob.Description;
            //ApplicationUser = theJob.ApplicationUser;
            //JobLocation = theJob.Location;
            //PayRate = theJob.PayRate;
            //RequiredSkills = theJob.RequiredSkills;
            //PreferredSkills = theJob.PreferredSkills;
            
        }

        public AddJobViewModel() { }

    }
}
