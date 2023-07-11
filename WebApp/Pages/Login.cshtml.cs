using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {


        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Here you can validate the user credentials against your database
            // Retrieve the user from your database.
            userService UserService = new userService();
            var user = UserService.getUserByName(UserName);

            if (user == null)
            {
                // User with the given username doesn't exist.
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            if (Password != user.Password)
            {
                // Passwords don't match.
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // User has provided valid credentials. Proceed with your login process...
            await SignInUser();

            HttpContext.Session.SetString("LoggedInUserName", user.Name);


            return RedirectToPage("/Index");
        }

        private async System.Threading.Tasks.Task SignInUser()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, UserName)
        };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

        }




    }
}
