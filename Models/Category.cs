using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}