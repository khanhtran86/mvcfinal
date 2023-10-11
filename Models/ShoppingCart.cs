namespace mvcprojectfinal.Models
{
    public class ShoppingCart
    {
        private List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        public List<ShoppingCartItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        public int Qty
        {
            get
            {
                return this.Items.Sum(t => t.Qty);
            }
        }

        public float Total
        {
            get
            {
                return this.Items.Sum(t => t.Qty * t.UnitPrice);
            }
        }
    }
}
