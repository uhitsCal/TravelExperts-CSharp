// Written by Keegan

using Microsoft.AspNetCore.Mvc;
using TravelExpertsData;

namespace TravelExperts.Controllers
{
    public class PackagesController : Controller
    {
        private TravelExpertsContext db;

        public PackagesController(TravelExpertsContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Package> packages = db.Packages.ToList();

            return View(packages);
        }
    }
}
