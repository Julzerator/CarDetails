using System.ComponentModel.DataAnnotations;

namespace CarDetails.Models
{
    public class Enquiry
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
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