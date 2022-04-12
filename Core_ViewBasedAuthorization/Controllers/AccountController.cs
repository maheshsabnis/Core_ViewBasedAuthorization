using Core_ViewBasedAuthorization.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core_ViewBasedAuthorization.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            Users user = new Users();
            return View(user);
        }


        /// <summary>
        /// The Login Post Request
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(Users user)
        {
            var usrs = new Users();
            // Read Password, Role and DateOfBirth
            var result = usrs.GetUsers().FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (result != null) // Check DB value
            {
                // Setting the Claim
                var userClaims = new List<Claim>()
                        {
                        new Claim(ClaimTypes.Name, result.Username),
                        new Claim(ClaimTypes.Role, result.Role),
                        new Claim(ClaimTypes.DateOfBirth, result.DateOfBirth.ToString()),
                        };
                // Generating Identity
                var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                // The Current USers Identity that will be Set to
                // HTTPContext for SignIn
                var userPrincipal = new ClaimsPrincipal(new[] { identity });
                // The USer will be SIgnIn and its Identity
                // is set for the Current Http Request
                // This will be accessible using 
                // UserPrincipal e.g. context.User
                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Employee");
            }

            return View(user);
        }

        public async Task<ActionResult> Logout()
        {
            //SignOut
            // Delete COokie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", new Users());
        }
    }
}
