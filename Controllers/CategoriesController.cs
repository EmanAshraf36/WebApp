using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.Controllers;

public class CategoriesController : Controller
{
    // GET
    public IActionResult Index()
    {
        var categories = CategoriesRepository.GetCategories();
        return View(categories);
    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
                return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if(ModelState.IsValid)
        {
            CategoriesRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction("Index");
        }
        return View(category);
    }
    [HttpPost]
    public IActionResult Add(Category category)
    {
        if(ModelState.IsValid)
        {
            CategoriesRepository.AddCategory(category);
            return RedirectToAction("Index");
        }
        return View(category);
    }
}