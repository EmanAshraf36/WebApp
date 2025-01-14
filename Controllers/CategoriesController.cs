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
        ViewBag.Action = "edit";
        var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
                return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if(ModelState.IsValid)
        {
            ViewBag.Action = "edit";
            CategoriesRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction("Index");
        }
        return View(category);
    }
    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Action = "add";
        return View();
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
    
    public IActionResult Delete(int categoryId)
    {
        CategoriesRepository.DeleteCategory(categoryId);
        return RedirectToAction("Index");
        
    }
}