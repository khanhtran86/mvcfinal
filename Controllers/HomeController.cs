using mvcprojectfinal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Models;
using System.Diagnostics;
using mvcprojectfinal.Models.Repository; 

namespace mvcprojectfinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;
        private IShoppingCartRepository shoppingCart;
        public HomeController(ILogger<HomeController> logger, IProductRepository _productRepository, IShoppingCartRepository shoppingCart)
        {
            _logger = logger;
            this.productRepository = _productRepository;
            this.shoppingCart = shoppingCart;
        }

        public IActionResult Index(int? page)
        {
            ViewData["TotalProduct"] = this.productRepository.GetTotalProductPage();
            IEnumerable<Product> lstProducts = this.productRepository.GetProducts(page.HasValue? page.Value:1);
            return View(lstProducts);
        }

        [HttpPost]
        public IActionResult Product(ShoppingCartItem cartItem)
        {
            var product = this.productRepository.GetProduct(cartItem.ProductId);
            cartItem.Product = product;
            cartItem.Qty = (cartItem.Qty == 0 ? 1 : cartItem.Qty);
            cartItem.UnitPrice = product.Price;

            this.shoppingCart.Add(cartItem);

            return View(cartItem);
        }

        [HttpPost]
        [HttpGet]
        [Authorize]
        public IActionResult CheckOut()
        {
            ShoppingCart cart = this.shoppingCart.GetShoppingCart();
            return View(cart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}