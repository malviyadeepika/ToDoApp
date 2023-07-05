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


namespace WebApp.Pages.Working
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CoreLogic.Model.Task task { get; set; } = default!;
        taskService taskservice;

        public CreateModel()
        {
            taskservice = new taskService();
        }

      
        public IActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {

            taskservice.createTask(task);

            return RedirectToPage("../Index");
        }
    }
}