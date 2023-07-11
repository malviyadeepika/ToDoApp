using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Working
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public CoreLogic.Model.Task task { get; set; }

        taskService taskService;
        public DeleteModel()
        {
            taskService = new taskService();
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            task = taskService.getTaskById(id.Value);

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null) return NotFound();

            taskService.deleteTaskById(id.Value);

            return RedirectToPage("./Index");
        }
    }
}