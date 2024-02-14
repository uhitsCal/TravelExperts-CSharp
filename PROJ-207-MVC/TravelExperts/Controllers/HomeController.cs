using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TravelExperts.Models;
using TravelExpertsData;

namespace TravelExperts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TravelExpertsContext _context { get; set; }
        int? currentUserId = 0;

        public HomeController(ILogger<HomeController> logger, TravelExpertsContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            currentUserId = HttpContext.Session.GetInt32("CurrentUser");
            if (currentUserId != null)
            {
                HttpContext.Session.SetInt32("currentUserId", (int)currentUserId);
            }
            return View();
        }


        [HttpGet]
        public IActionResult UpdateProfile()
        {
            var currentUserIds = HttpContext.Session.GetInt32("currentUserId");
            Customer obj = new Customer();
            if (currentUserIds > 0)
            {
                obj = _context.Customers.FirstOrDefault(c => c.CustomerId == currentUserIds);
            }
            else
            {
                return RedirectToAction("Login", "Customer"); // Assuming you have a Login action in the CustomerController
            }

            // Continue with the action logic
            // ...
            return View(obj);
        }


        // Update Function
        [HttpPost]
        public ActionResult UpdateProfile(Customer model)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(x => x.CustomerId == model.CustomerId);

            if (existingCustomer != null)
            {
                // Update the existing customer information here
                existingCustomer.CustFirstName = model.CustFirstName;
                existingCustomer.CustLastName = model.CustLastName;
                existingCustomer.CustAddress = model.CustAddress;
                existingCustomer.CustCity = model.CustCity;
                existingCustomer.CustProv = model.CustProv;
                existingCustomer.CustPostal = model.CustPostal;
                existingCustomer.CustCountry = model.CustCountry;
                existingCustomer.CustHomePhone = model.CustHomePhone;
                existingCustomer.CustBusPhone = model.CustBusPhone;
                existingCustomer.CustEmail = model.CustEmail;
                existingCustomer.AgentId = model.AgentId;
                existingCustomer.CustPassword = model.CustPassword;
                existingCustomer.CustConfirmPassword = model.CustConfirmPassword;

                string input = model.CustHomePhone;
                string input2 = model.CustBusPhone;
                string ChkPst = model.CustPostal;
                string ChkEml = model.CustEmail;




                string pattern = @"D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$";
                string PstPattern = @"[A-Za-z]\d[A-Za-z][-]?\d[A-Za-z]\d";
                string EmlPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";


                // Save the changes to the database after validations
                if (model.CustFirstName == null)
                {
                    TempData["Message"] = "First Name is Required";
                }
                else if (model.CustLastName == null)
                {

                    TempData["Message"] = "Last Name is Required";
                }
                else if (model.CustAddress == null)
                {

                    TempData["Message"] = "Address is Required";
                }

                else if (model.CustCity == null)
                {

                    TempData["Message"] = "City is Required";
                }
                else if (model.CustProv == null)
                {

                    TempData["Message"] = "Province is Required";
                }

                else if (model.CustPostal == null || !Regex.IsMatch(ChkPst, PstPattern))
                {

                    TempData["Message"] = " Valid Postal Code is Required";
                }
                else if (model.CustCountry == null)
                {

                    TempData["Message"] = "Contry is Required";
                }
                else if (model.CustHomePhone == null || !Regex.IsMatch(input, pattern))
                {

                    TempData["Message"] = "Valid Home Phone is Required ";
                }
                else if (model.CustBusPhone == null || !Regex.IsMatch(input2, pattern))
                {

                    TempData["Message"] = " Valid Business Phone  is Required";
                }


                else if (model.CustPassword == null)
                {

                    TempData["Message"] = "Password  is Required";
                }
                else if (model.CustConfirmPassword == null || model.CustConfirmPassword != model.CustPassword)
                {

                    TempData["Message"] = "Confirm Password must not be empty and must match the password";
                }
                else if (model.CustEmail == null || !Regex.IsMatch(ChkEml, EmlPattern))
                {

                    TempData["Message"] = " Valid Email is Required";
                }

                else
                {
                    _context.SaveChanges();
                    TempData["Message"] = "Data Updated Successfully";
                }


                if (existingCustomer.CustPassword != model.CustPassword)
                {
                    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.Session.Remove("CurrentUser"); // no more current owner
                    return RedirectToAction("Login", "Account"); // default page
                }
            }
            else
            {
                TempData["Message"] = "Customer with this email does not exist.";
            }

            return View(); // Redirect to the appropriate view after the update attempt.
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}