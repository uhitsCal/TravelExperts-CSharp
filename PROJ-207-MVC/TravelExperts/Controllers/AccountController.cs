using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelExpertsData;

namespace TravelExperts.Controllers
{
    //Contributor: Calvin C
    public class AccountController : Controller
    {
        private TravelExpertsContext _context { get; set; }
        public AccountController(TravelExpertsContext context)
        {
            _context = context;
        }

        // returnUrl is the method that required login
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != null) // preserve return URL
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer user) // from the login view
        {
            HttpContext.Session.Remove("CurrentUser"); // no more current owner
            Customer? usr = CustomerManager.Authenticate(_context, user.CustUsername, user.CustPassword);
            if (usr == null)// failed authentication
            {
                return View(); // stay on the login page
            }
            // usr is an User object - authenticated user


            HttpContext.Session.SetInt32("CurrentUser", (int)usr.CustomerId); //set the session id to the user id


            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usr.CustUsername),//set the username as a name for the claim
                new Claim(ClaimTypes.Sid, usr.CustomerId.ToString()) //set the customerId as the id for the claim
            };
            ClaimsIdentity claimsIndentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme); // cookies authentication
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIndentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal);

            // redirect to the return URL if exists
            if (TempData["ReturnUrl"] == null ||
                String.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
            {
                return RedirectToAction("Index", "Home"); // redirect to the Home/Index page if no return url
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("CurrentUser"); // no more current owner
            return RedirectToAction("Index", "Home"); // default page
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
