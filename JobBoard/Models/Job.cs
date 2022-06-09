using System;
using System.Collections.Generic;

namespace JobBoard.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public string Location { get; set; }
        public string PayRate { get; set; }

        public string RequiredSkills { get; set; }
        public string PreferredSkills { get; set; }


        public Job()
        {
        }

        public Job(string name, string location, string description, string payRate, string reqSkills, string prefSkills)
        {
            Name = name;
            Location = location;
            Description = description;
            PayRate = payRate;
            RequiredSkills = reqSkills;
            PreferredSkills = prefSkills;
        }
    }
}
