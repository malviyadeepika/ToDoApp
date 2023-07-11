using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Task
{
    public class IndexModel : PageModel
    {
        userService us;
        public User user { get; set; }
        public void OnGet()
        {
            us = new userService();
            var name = HttpContext.Session.GetString("LoggedInUserName");
            user = us.getUserByName(name);

            

            //users = users.OrderBy(u => u.Id).ToList();
        }
    }
}