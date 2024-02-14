using System;
using System.Collections.Generic;

namespace PROJ_207_Project_2.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? SupName { get; set; }

    public virtual ICollection<ProductSupplier> ProductsSuppliers { get; set; } = new List<ProductSupplier>();

    public virtual ICollection<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();
}
