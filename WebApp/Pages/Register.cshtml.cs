using CoreLogic.Services;
using CoreLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {


        public User User;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            userService userService = new userService();
            var existingUser = userService.getUserByName(Name);

            if (existingUser != null)
            {
                
                ModelState.AddModelError(string.Empty, "Username already taken.");
                return Page();
            }

            if (Password != ConfirmPassword)
            {

                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            User newUser = new User
            {
                Name = Name,
                Password = Password,
                Email = Email
            };
            userService.createUser(newUser);

            await SignInUser();

            return RedirectToPage("/Products/Index");
        }

        private async Task SignInUser()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Name)
        };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
