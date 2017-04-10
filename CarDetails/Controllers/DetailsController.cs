using System.Web.Mvc;
using CarDetails.Models;

namespace CarDetails.Controllers
{
    public class DetailsController : Controller
    {
        [HttpGet]
        public ActionResult Details(string carid)
        {
            var car = Car.Details(carid);
            string mainInfo = car.Year + " " +
                            car.Make + " " +
                            car.Model + " for $" + car.Price;
            ViewBag.CarId = car.CarId;
            ViewBag.CarMain = mainInfo;
            ViewBag.ListingType = car.ListingType.ToString();
            ViewBag.SellerEmail = car.Email;
            ViewBag.DealerABN = car.DealerAbn;
            ViewBag.ContactName = car.ContactName;
            ViewBag.Phone = car.Phone;
            ViewBag.Comments = car.Comments;
            return View();
        }

        [HttpPost]
        public ActionResult Enquire(Enquiry enquiry)
        {
            var car = Car.Details(enquiry.CarId);
            car.AddEnquiryToCar(enquiry);
            ViewBag.Name = enquiry.Name;
            return RedirectToAction("Success", "Details");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}