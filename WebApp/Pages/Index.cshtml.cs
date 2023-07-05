using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        UserServices userservice;
        public List<User> user { get; set; }
        public void OnGet()
        {
            userservice = new UserServices();
            user = userservice.GetAll();
        }
    }
}