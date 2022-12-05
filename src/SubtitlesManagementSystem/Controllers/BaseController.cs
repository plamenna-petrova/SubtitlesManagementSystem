using Microsoft.AspNetCore.Mvc;

namespace SubtitlesManagementSystem.Controllers
{
    public class BaseController: Controller
    {
        protected IActionResult RedirectToIndexActionInCurrentController()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
