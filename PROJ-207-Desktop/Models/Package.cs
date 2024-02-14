using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROJ_207_Project_2.Models;

public  class Package
{
    public int PackageId { get; set; }

    public string PkgName { get; set; } = null!;

    public DateTime PkgStartDate { get; set; }

    public DateTime PkgEndDate { get; set; }

    public string? PkgDesc { get; set; }

    public decimal PkgBasePrice { get; set; }

    public decimal? PkgAgencyCommission { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; } = new List<PackagesProductsSupplier>();
}
