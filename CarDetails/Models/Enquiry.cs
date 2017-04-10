using System.Collections.Generic;

namespace CarDetails.Models
{
    public class Enquiry
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CarId { get; set; }

        public void Create(string name, string email)
        {
            Enquiry ask = new Enquiry
            {
                Name = name,
                Email = email
            };
        }
    }
}