//Author: Gabriel V Gomes
//When: July 2023

namespace TravelExperts.Models
{
    public class PackagesViewModel
    {
        public int? PackageId { get; set; }

        public string PkgName { get; set; } = null!;

        public DateTime? PkgStartDate { get; set; }

        public DateTime? PkgEndDate { get; set; }

        public decimal PkgBasePrice { get; set; }

        public string? PkgDesc { get; set; }

        public decimal? PkgAgencyCommission { get; set; }
    }
}
