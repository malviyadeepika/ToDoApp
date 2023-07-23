using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;
[Authorize]
public class IndexModel : PageModel
{
    userService us;

    [BindProperty]
    public User user { get; set; } = default!;
    public void OnGet()
    {
        us = new userService();
        var name = HttpContext.Session.GetString("LoggedInUserName");
        user = us.getUserByName(name);
        Console.WriteLine(user);
    }
}
