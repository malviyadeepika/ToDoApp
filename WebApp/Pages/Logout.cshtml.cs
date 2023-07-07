using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class LogoutModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync("CookieAuth");

        return RedirectToPage("/Login");
    }
}