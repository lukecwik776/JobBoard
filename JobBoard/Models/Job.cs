﻿using System;
using System.Collections.Generic;

namespace JobBoard.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Employer Employer { get; set; }

        public int EmployerId { get; set; }

        public string Location { get; set; }
        public string PayRate { get; set; }

        public List<string> RequiredSkills { get; set; }
        public List<string> PreferredSkills { get; set; }

        public Job()
        {
        }

        public Job(string name, string location, string description, string payRate, List<string> reqSkills, List<string> prefSkills)
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
