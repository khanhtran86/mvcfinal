using System;
namespace mvcprojectfinal.Models
{
	public class ShoppingCartItem
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Qty { get; set; }
		public float UnitPrice { get; set; }

		public Product Product { get; set; }
	}
}

