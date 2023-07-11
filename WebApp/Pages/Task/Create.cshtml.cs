using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreLogic.Data;
using CoreLogic.Model;
using CoreLogic.Services;


namespace WebApp.Pages.Working;  

public class CreateModel : PageModel
{
    [BindProperty]
    public CoreLogic.Model.Task task { get; set; } = default!;
    taskService taskservice;
    userService userservice;


        public CreateModel()
            {
                taskservice = new taskService();
                userservice = new userService();
            }


    public IActionResult OnGet()
    {
        return Page();
    }

    public ActionResult OnPost()
    {

        var name = HttpContext.Session.GetString("LoggedInUserName");
        var user = userservice.getUserByName(name);

        task.UserId = user.Id;

        taskservice.createTask(task);


        return RedirectToPage("./Index");
    }
}