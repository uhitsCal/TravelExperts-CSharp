using System;
using System.Collections.Generic;

namespace PROJ_207_Project_2.Models;

public partial class Product
{
	// How many characters wide does the ID column take up for displaying products.
	public const int ID_COLUMN_WIDTH = 5;

    public int ProductId { get; set; }

    public string ProdName { get; set; } = null!;

    public virtual ICollection<ProductSupplier> ProductsSuppliers { get; set; } = new List<ProductSupplier>();

	public override string ToString()
	{
		return ProductId.ToString().PadRight(ID_COLUMN_WIDTH) + ProdName;
	}
}
