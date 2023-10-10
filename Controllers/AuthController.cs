using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Models;

namespace mvcprojectfinal.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult SignIn(string ReturnUrl)
        {
            return View();
        }

        public IActionResult GetToken(Customer customer, string ReturnUrl)
        {
            return View();
        }
    }
}
