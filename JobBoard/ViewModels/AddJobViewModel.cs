using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace JobBoard.ViewModels
{
    public class AddJobViewModel
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public double PayRate { get; set; }



    }
}
