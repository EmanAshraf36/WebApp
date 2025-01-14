using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}