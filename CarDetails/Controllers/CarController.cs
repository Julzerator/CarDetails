using System;
using System.IO;
using System.Web.Mvc;
using CarDetails.Models;

namespace CarDetails.Controllers
{
    public class CarController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (GlobalVariables.GlobalVariables.Cars.Count < 1)
            {
                LoadCars();
            }
            return View(Car.GetAll());
        }

        private void LoadCars()
        {
            string path = Server.MapPath("~/App_Data/CarData.txt");
            using (StreamReader file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] car = line.Split(';');
                    string make = car[0];
                    string model = car[1];
                    int year = Int32.Parse(car[2]);
                    int price = Int32.Parse(car[3]);
                    string email = car[4];
                    string comments = car[5];
                    string listingType = car[6];
                    string dealerAbn = car[7];
                    int? phone = null;
                    if (car[8].Length > 1)
                    {
                        phone = Int32.Parse(car[8]);
                    }
                    string contactName = "";
                    if (car.Length > 9)
                    {
                        contactName = car[9];
                    }
                    Car newCar = new Car();
                    newCar = newCar.Create(make, model, year, price, email, comments, listingType, dealerAbn, phone, contactName);
                    Car.AddCarToSite(newCar);
                }
            }
        }
    }
}