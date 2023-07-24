using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreLogic.Data;
using CoreLogic.Model;
using CoreLogic.Services;

namespace WebApp.Pages.Working;
    public class UpdateModel : PageModel
    {
    [BindProperty]
    public CoreLogic.Model.Task Task { get; set; }
    taskService taskService;
    userService userService;
    public List<SelectListItem> CategoryOptions { get; set; }

    public UpdateModel()
    {
        taskService = new taskService();
        userService = new userService();
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        Task = taskService.getTaskById(id.Value);
        var categories = taskService.getAllCategories();

        PopulateCategoriesDropDown();
        return Page();
    }

    public ActionResult OnPost(int? id)
    {
        if (id == null) return NotFound();

        if (!ModelState.IsValid || Task == null)
        {
            PopulateCategoriesDropDown();
            return Page();
        }
        taskService.updateTask(Task);


        return RedirectToPage("/Index");
    }

    private void PopulateCategoriesDropDown()
    {
        var categories = taskService.getAllCategories();

        CategoryOptions = categories.Select(category =>
                                  new SelectListItem
                                  {
                                      Value = category.Id.ToString(),
                                      Text = category.Name
                                  }).ToList();
    }
}
