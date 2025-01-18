namespace WebApp.Models;

public static class CategoriesRepository
{
    private static List<Category> _categories = new List<Category>()
    {
        new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
        new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
        new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
    };

    public static void AddCategory(Category category)
    {
        if (_categories != null && _categories.Count > 0)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
        }
        else
        {
            category.CategoryId = 1;
        }
        if(_categories == null) _categories = new List<Category>();
        _categories.Add(category);
    } //Add

    public static List<Category> GetCategories() => _categories; //return

    public static Category? GetCategoryById(int categoryId)
    {
        var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (category != null)
        {
            //new copy
            return new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }
        return null;
    }
    //the category object is the updated version of the category
    public static void UpdateCategory(int categoryId, Category category)
    {
        if (categoryId != category.CategoryId) return;
        var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
        }
    }

    public static void DeleteCategory(int categoryId)
    {
        var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (category != null)
        {
            _categories.Remove(category);   
        }
    }
}