using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        var products = ProductsRepository.GetProducts(loadCategory:true);
        return View(products);
    }
    [HttpGet]
    public IActionResult Add()
    {
        var productViewModel = new ProductViewModel
        {
            Categories = CategoriesRepository.GetCategories()
        };
        return View(productViewModel);
    }
    [HttpPost]
    public IActionResult Add(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            ProductsRepository.AddProduct(productViewModel.Product);
            return RedirectToAction("Index");
        }

        productViewModel.Categories = CategoriesRepository.GetCategories();
        return View(productViewModel);
    }
}

