using System;
using System.Collections.Generic;

namespace PROJ_207_Project_2.Models;

public partial class Affiliation
{
    public string AffilitationId { get; set; } = null!;

    public string? AffName { get; set; }

    public string? AffDesc { get; set; }

    public virtual ICollection<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();
}
