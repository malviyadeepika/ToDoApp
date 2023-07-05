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
    public UpdateModel()
    {
        taskService = new taskService();
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        Task = taskService.getTaskById(id.Value);

        return Page();
    }

    public IActionResult OnPost(int? id)
    {
        if (id == null) return NotFound();

        taskService.updateTask(Task);

        return RedirectToPage("../Index");
    }
}
