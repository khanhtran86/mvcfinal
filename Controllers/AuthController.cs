using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        [HttpPost]
        public async Task<IActionResult> GetToken(Customer customer, string ReturnUrl)
        {
            await HttpContext.SignOutAsync();

            if (customer.Email == "txk2601@gmail.com" && customer.Password == "123456")
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, $"{customer.FirstName} {customer.LastName}"),
                    new Claim(ClaimTypes.Email, customer.Email),
                    new Claim(ClaimTypes.Role , "Customer")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return LocalRedirect(ReturnUrl);
            }
            else
            {
                return Unauthorized();
            }    
        }
    }
}
