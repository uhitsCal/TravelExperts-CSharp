using System;
using System.Collections.Generic;

namespace PROJ_207_Project_2.Models;

public partial class PackagesProductsSupplier
{
    public int PackageProductSupplierId { get; set; }

    public int PackageId { get; set; }

    public int ProductSupplierId { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual ProductSupplier ProductSupplier { get; set; } = null!;
}
