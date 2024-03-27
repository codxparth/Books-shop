using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult DiffCategories()
        {
            return View();
        }
    }
}
