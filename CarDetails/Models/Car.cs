using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDetails.Models
{
    public class Car
    {
        [Key]
        public string CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

        [Display(Name = "Dealer ABN")]
        public string DealerAbn { get; set; }

        public int Phone { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Listing Type")]
        public ListingType ListingType { get; set; }

        public List<Enquiry> Enquiries { get; set; } = new List<Enquiry>();

        public Car Create(string make, string model, int year, int price, string email, string comments, string listingType, string dealerAbn, int? phone, string contactName)
        {
            string carId = Guid.NewGuid().ToString();
            Car car = new Car
            {
                CarId = carId,
                Make = make,
                Model = model,
                Year = year,
                Price = price,
                Email = email,
                Comments = comments
            };

            if (listingType == "Dealer")
            {
                Dealer(car, dealerAbn);
            }
            else if (listingType == "Private" && phone.HasValue)
            {
                Private(car, phone.Value, contactName);
            }
            return car;
        }

        public static void AddCarToSite(Car car)
        {
            GlobalVariables.GlobalVariables.Cars.Add(car);
        }

        private void Dealer(Car car, string dealerAbn)
        {
            car.ListingType = ListingType.Dealer;
            car.DealerAbn = dealerAbn;
        }

        private void Private(Car car, int phone, string contactName)
        {
            car.ListingType = ListingType.Private;
            car.Phone = phone;
            car.ContactName = contactName;
        }

        public static List<Car> GetAll()
        {
            return GlobalVariables.GlobalVariables.Cars;
        }

        public static Car Details(string carId)
        {
            foreach (var car in GlobalVariables.GlobalVariables.Cars)
            {
                if (car.CarId == carId)
                    return car;
            }
            return null;
        }

        public void AddEnquiryToCar(Enquiry enquiry)
        {
            Enquiries.Add(enquiry);
        }
    }

    public enum ListingType
    {
        Dealer,
        Private
    }

}