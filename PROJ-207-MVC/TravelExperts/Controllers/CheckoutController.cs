// Written by Keegan

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.PackageExtraction;
using System.Security.Claims;
using TravelExperts.Models;
using TravelExpertsData;

namespace TravelExperts.Controllers
{
	[Authorize]
	public class CheckoutController : Controller
	{
		private TravelExpertsContext db;

		public CheckoutController(TravelExpertsContext db)
		{
			this.db = db;
		}

		private int GetCustomerId()
		{
			return Int32.Parse(User.FindFirstValue(ClaimTypes.Sid));
		}

		public IActionResult Index(int id)
		{
			Package? package = db.Packages.Find(id);

			if (package == null)
				return View("Error");

			ViewBag.package = package;

			try {
				int customerId = GetCustomerId();
				CreditCard card = db.CreditCards.First(c => c.CustomerId == customerId);

				CheckoutModel checkout = new CheckoutModel();

				checkout.CardNumber = card.Ccnumber;
				checkout.Expiry = card.Ccexpiry.Date.ToString("yy\\/MM");

				return View(checkout);
			} catch {
				return View();
			}
		}

		[HttpPost]
		public IActionResult Index(int id, CheckoutModel checkout)
		{
			Package? package = db.Packages.Find(id);

			if (package == null)
				return View("Error");

			if (!ModelState.IsValid) {
				ViewBag.package = package;
				return View(checkout);
			}

			int customerId = GetCustomerId();

			db.Bookings.Add(new Booking() {
				BookingDate = DateTime.Now,
				CustomerId = customerId,
				PackageId = id,
				TravelerCount = checkout.TravelerCount,
				TripTypeId = "L"
			});

			// Delete existing entry(s) so this one appears later.
			db.CreditCards.Where(c => c.CustomerId == customerId).ExecuteDelete();

			if (checkout.RememberPayment) {
				db.CreditCards.Add(new CreditCard() {
					Ccexpiry = DateTime.ParseExact(checkout.Expiry, "yy/MM", null),
					Ccname = "VISA",
					Ccnumber = checkout.CardNumber,
					CustomerId = customerId
				});
			}

			db.SaveChanges();

			return RedirectToAction("ThankYou");
		}

		public IActionResult ThankYou()
		{
			return View();
		}
	}
}
