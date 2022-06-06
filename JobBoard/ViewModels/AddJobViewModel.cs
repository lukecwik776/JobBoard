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
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public string PayRate { get; set; }
        public string RequiredSkills { get; set; }
        public string PreferredSkills { get; set; }

        public AddJobViewModel(List<Employer> registeredEmployers)
        {
            Employers = new List<SelectListItem>();

            foreach (var employer in registeredEmployers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }
        }

        public AddJobViewModel() { }

    }
}
