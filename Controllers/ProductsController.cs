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
        ViewBag.Action = "add";
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
        ViewBag.Action = "add";
        productViewModel.Categories = CategoriesRepository.GetCategories();
        return View(productViewModel);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Action = "edit";
        var productViewModel = new ProductViewModel
        {
            Product = ProductsRepository.GetProductById(id)?? new Product(),
            Categories = CategoriesRepository.GetCategories()
        };
            return View(productViewModel);
    }
    [HttpPost]
    public IActionResult Edit(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
            return RedirectToAction("Index");
        }
        ViewBag.Action = "edit";
        productViewModel.Categories = CategoriesRepository.GetCategories();
        return View(productViewModel);
    }
    
}





