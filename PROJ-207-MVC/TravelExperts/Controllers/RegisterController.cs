using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelExperts.Models;
using TravelExpertsData;

namespace TravelExperts.Controllers
{
    //Contributor: Calvin C
    public class RegisterController : Controller
    {
        private TravelExpertsContext _context { get; set; }
        public RegisterController(TravelExpertsContext context)
        {
            _context = context;
        }
        public IActionResult Index() //default view
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            string msg = check.UserNameExists(_context, customer.CustUsername); //check if the username of the currrent customer exist
            if (!String.IsNullOrEmpty(msg)) //if check returns not null
            {
                ModelState.AddModelError(nameof(Customer.CustUsername), msg); //print out message of validation
            }

            if (ModelState.IsValid) //if all validation goes through
            {
                _context.Customers.Add(customer); //add to customers database
                _context.SaveChanges(); //save db
                return RedirectToAction("Welcome"); //direct to welcome page
            }
            else //id not then return back with data
            {
                return View(customer);
            }
        }




        public IActionResult Welcome() => View();
    }
}
