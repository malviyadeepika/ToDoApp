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
    //taskService taskService;

    [BindProperty]
    public User user { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? search { get; set; } = default;

    public void OnGet()
    {
        us = new userService();
        //taskService=new taskService();
        var name = HttpContext.Session.GetString("LoggedInUserName");
       user = us.getUserByName(name);
        //user = us.getUserBySearch(name, search);
        
        user = us.getUserByName(name);
        Console.WriteLine(user);
    }
}
