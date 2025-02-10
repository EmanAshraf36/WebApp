using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels.Validations;

public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

        if (salesViewModel != null)
        {
            if (salesViewModel.QuantityToSell <= 0)
            {
                return new ValidationResult("Quantity must be greater than 0");
            }
            else
            {
                var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                if (product != null)
                {
                    if (product.Quantity < salesViewModel.QuantityToSell)
                        return new ValidationResult($"{product.Name} only has {product.Quantity} left which is not enough to be sold.");
                }
                else
                {
                    return new ValidationResult("The selected product doesn't exist.");
                }
            }
        }
            
            
            
            
        return ValidationResult.Success;
    }
}