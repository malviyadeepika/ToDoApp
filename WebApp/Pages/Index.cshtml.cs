using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    { 
        userService us;
        public List<User> users { get; set; }
        public void OnGet()
        {
            us = new userService();
            users = us.GetAllUsers();
            //users = users.OrderBy(u => u.Id).ToList();
        }
    }
}