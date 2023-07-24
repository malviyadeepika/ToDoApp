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
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            userService userService = new userService();
            var existingUser = userService.getUserByName(Name);
            if (!ModelState.IsValid)
            {
                return Page();
            }

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
                Email = Email,
                Password = Password, 
            };
            userService.createUser(newUser);

            await SignInUser();

            return RedirectToPage("/Login");
        }

        private async System.Threading.Tasks.Task SignInUser()
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
