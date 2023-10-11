using System;
using mvcprojectfinal.Models.DataContext;

namespace mvcprojectfinal.Models.Repository
{
	public interface IShoppingCartRepository
	{
        public void Add(ShoppingCartItem item);

        public ShoppingCart GetShoppingCart();
	}

    public class ShoppingCartRepository : RepositoryBase, IShoppingCartRepository
    {
        const string SHOPPING_CART_KEY = "ShoppingCart";
        private AppDataContext dbContext;
        private IHttpContextAccessor contextAccessor;
        public ShoppingCartRepository(AppDataContext _dbContext, IConfiguration appConfig, IHttpContextAccessor contextAccessor) : base(appConfig)
        {
            this.dbContext = _dbContext;
            this.contextAccessor = contextAccessor;
        }

        public void Add(ShoppingCartItem item)
        {
            ShoppingCart cart = this.contextAccessor.HttpContext.Session.Get<ShoppingCart>(SHOPPING_CART_KEY);
            if(cart!=null)
            {
                var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if(cartItem!=null)
                {
                    cartItem.Qty += item.Qty;
                }
                else
                {
                    cart.Items.Add(item);
                }
            }
            else
            {
                cart = new ShoppingCart();
                cart.Items.Add(item);
            }

            this.contextAccessor.HttpContext.Session.Set<ShoppingCart>(SHOPPING_CART_KEY, cart);
        }

        public ShoppingCart GetShoppingCart()
        {
            return this.contextAccessor.HttpContext.Session.Get<ShoppingCart>(SHOPPING_CART_KEY);
        }
    }
}

