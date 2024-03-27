using Book.Context;
using Microsoft.AspNetCore.Mvc;
    
namespace Book.Controllers
{

   
    public class LRController : Controller
    {
        public BookDbContext DbContext;
        public  LRController(BookDbContext dbContext) {
        this.DbContext=dbContext;

        
        }
        public IActionResult Index()
        {
            return View();
        }
            public IActionResult Login()
    {
        if (HttpContext.Session.GetString("UserSession") != null)
        {

            return RedirectToAction("Index","Home");
        }
        return View();
    }
    [HttpPost]
    public IActionResult Login(RegisterModel user)
    {
        var myuser = DbContext.UserTable.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
        if (myuser != null)
        {
            HttpContext.Session.SetString("UserSession", myuser.Email);
            return RedirectToAction("Index","Home");
        }
        else
        {
            ViewBag.Message = "login failed";
        }

        return View();
    }
    public IActionResult Logout()
    {
        if (HttpContext.Session.GetString("UserSession") != null)
        {
            HttpContext.Session.Remove("UserSession");
            return RedirectToAction("Login");
        }

        return View();
    }
    public IActionResult Register()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel user)
    {
        if (ModelState.IsValid)
        {

            await DbContext.UserTable.AddAsync(user);
            await DbContext.SaveChangesAsync();
            TempData["success"] = "successfully registered";
            return RedirectToAction("Login");

        }
        return View();
    }

    }
}
