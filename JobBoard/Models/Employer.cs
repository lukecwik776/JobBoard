using System;
namespace JobBoard.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Employer()
        {
        }

        public Employer(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
