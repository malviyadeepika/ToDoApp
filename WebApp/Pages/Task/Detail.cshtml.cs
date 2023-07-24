using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.Task;

[Authorize]

public class DetailModel : PageModel
{
    [BindProperty]
    public CoreLogic.Model.Task task { get; set; } = default!;
    public IActionResult OnGet(int ?id)
    {
        if (id == null)
            return NotFound();

        taskService taskservice = new taskService();
        task=taskservice.getTaskById(id.Value);

        if (task == null) return NotFound();

        return Page();
    }
}
