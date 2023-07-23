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
    public List<SelectListItem> CategoryOptions { get; set; }
    taskService taskservice;
    userService userservice;


        public CreateModel()
            {
                taskservice = new taskService();
                userservice = new userService();
            }


    public IActionResult OnGet()
    {
            var categories = taskservice.getAllCategories();
            PopulateCategoriesDropDown();
            return Page();
    }

    public ActionResult OnPost()
    {
        var name = HttpContext.Session.GetString("LoggedInUserName");
        var user = userservice.getUserByName(name);

        task.UserId = user.Id;
        if (!ModelState.IsValid || task == null)
        {
            PopulateCategoriesDropDown();
            return Page();
        }
        taskservice.createTask(task);

        return RedirectToPage("/Index");
    }
    private void PopulateCategoriesDropDown()
    {
        var categories = taskservice.getAllCategories();

        CategoryOptions = categories.Select(category =>
                                  new SelectListItem
                                  {
                                      Value = category.Id.ToString(),
                                      Text = category.Name
                                  }).ToList();
    }

}